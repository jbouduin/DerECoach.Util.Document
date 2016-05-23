using System;
using System.IO;
using System.Reflection;
using System.Text;
using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Rtf.Attributes;
using Bouduin.Util.Document.Rtf.Document;

namespace Bouduin.Util.Document.Rtf
{
    /// <summary>
    /// Reflects Document generating an RTF string which is written to a file.
    /// </summary>
    public class RtfWriter
    {
        #region fields --------------------------------------------------------

        private const int PreferredWidth = 128;

        private readonly RtfDocumentInfo _rtfDocumentInfo; 
        private StringBuilder _stringBuilder;
        private Encoding _encoding;
        private int _lastNewLineIndex;
        #endregion


        /// <summary>
        /// Writes Document to a file.
        /// </summary>
        /// <param name="writer">The System.IO.TextWriter used to write the document.</param>
        /// <param name="document">The IDocument to write.</param>
        public void Write(TextWriter writer, IDocument document)
        {
            var doc = document as Generic.Document.Document;
            // ReSharper disable once PossibleNullReferenceException
            _encoding = Encoding.GetEncoding((int)doc.CodePage);
            
            _stringBuilder = new StringBuilder();

            Reflect(doc);

            writer.Write(_stringBuilder.ToString());
        }

        #region constructor ---------------------------------------------------

        public RtfWriter()
        {
            _rtfDocumentInfo = new RtfDocumentInfo();
        }
        #endregion
        
        #region helper methods ------------------------------------------------
        private void Reflect(object instance)
        {
            Reflect(instance, -1);
        }

        private void Reflect(object instance, int arrayIndex)
        {
            var type = instance.GetType();

            var info = _rtfDocumentInfo.GetAttributeInfo(type);

            string
                controlWord = info.RtfControlWordAttribute != null ? @"\" + info.RtfControlWordAttribute.Name : string.Empty,
                controlWordDenotingEnd = info.RtfControlWordDenotingEndAttribute != null ? @"\" + info.RtfControlWordDenotingEndAttribute.Name : string.Empty;

            bool
                isIndexed = info.RtfControlWordAttribute != null && info.RtfControlWordAttribute.IsIndexed,
                enclosedWithBraces = info.EnclosingBracesAttribute != null && info.EnclosingBracesAttribute.Braces,
                closingSemicolon = info.EnclosingBracesAttribute != null && info.EnclosingBracesAttribute.ClosingSemicolon;
            
            if (enclosedWithBraces)
            {
                Append('{');
            }

            if (!string.IsNullOrEmpty(controlWord))
            {
                Append(controlWord);

                if (isIndexed && arrayIndex >= 0)
                    Append(arrayIndex.ToString());
            }

            var members = _rtfDocumentInfo.GetTypeMembers(type);

            foreach (var member in members)
            {
                ReflectMember(member, instance);
            }

            if (closingSemicolon)
                Append(';');

            if (!string.IsNullOrEmpty(controlWordDenotingEnd))
                Append(controlWordDenotingEnd);

            if (enclosedWithBraces)
                Append('}');
        }

        private void ReflectMember(MemberInfo member, object instance)
        {
            var info = _rtfDocumentInfo.GetAttributeInfo(member);

            if (!info.HasAnyRelevantAttribute)
                return;

            if (info.IgnoreAttribute != null)
                return;

            var include = true;

            if (info.IncludeAttribute != null)
                include = GetCondition(instance, info.IncludeAttribute);

            if (!include)
                return;

            var memberType = GetMemberType(member);
            var value = GetMemberValue(member, instance);

            if (info.RtfControlWordAttribute != null)
            {
                Append(GetControlWord(member, memberType, value, info.RtfControlWordAttribute.Name));

                if (memberType.IsClass)
                {
                    if (TypeIsIEnumerable(memberType))
                        ReflectArray(value);
                    else
                        Reflect(value);
                }

                return;
            }

            if (info.TextDataAttribute != null)
            {
                Append(' ');
                
                if (info.TextDataAttribute.Quotes)
                {
                    Append('"');
                }
                
                Append(EncodeText(value.ToString(), info.TextDataAttribute.TextDataType));

                if (info.TextDataAttribute.Quotes)
                {
                    Append('"');
                }

                return;
            }

            if (info.RtfControlGroupAttribute != null)
            {
                AppendLine();
                Append('{');
                Append('\\');
                Append(info.RtfControlGroupAttribute.Name);
                Append(' ');

                ReflectArray(value);

                Append('}');
                AppendLine();

                return;
            }

            // TODO remove this membertype.isclass
            if (info.IncludeAttribute != null && (memberType.IsClass || memberType.IsInterface))
            {
                if (TypeIsIEnumerable(memberType))
                    ReflectArray(value);
                else if (value != null)
                    Reflect(value);
            }
        }

        private void ReflectArray(object value)
        {
            var array = value as System.Collections.IEnumerable;
            
            var index = 0;

            if (array != null)
            {
                foreach (var arrayMember in array)
                    Reflect(arrayMember, index++);
            }
        }

        private string GetControlWord(MemberInfo member, Type memberType, object memberValue, string attributeControlWord)
        {
            if (memberType == null)
                throw (new ArgumentNullException(@"memberType", @"MemberType cannot be null"));

            var controlWord = memberType.IsEnum
                ? GetEnumControlWord(memberType, memberValue, attributeControlWord)
                : GetMemberControlWord(member, memberType, memberValue, attributeControlWord);

            return controlWord == @"\" ? string.Empty : controlWord;
        }

        private string GetMemberControlWord(MemberInfo member, Type memberType, object memberValue, string attributeControlWord)
        {
            if (memberType == null)
                throw (new ArgumentNullException(@"memberType", @"MemberType cannot be null"));

            if (memberType.IsEnum)
                throw (new ArgumentException(@"MemberType cannot be an enum", @"memberType"));

            var controlWord = @"\";
            
            if (!string.IsNullOrEmpty(attributeControlWord))
                controlWord += attributeControlWord;
            else
                controlWord += member.Name.ToLower();

            if (memberType.IsPrimitive)
            {
                if (memberType == typeof(int))
                {
                    var info = _rtfDocumentInfo.GetAttributeInfo(member);

                    if (info.IndexAttribute != null)
                    {
                        if ((int)memberValue >= 0)
                            controlWord += memberValue.ToString();
                        else
                            controlWord = string.Empty;
                    }
                    else
                        controlWord += memberValue.ToString();
                }
                else if (memberType != typeof(bool))
                {
                    controlWord += memberValue.ToString();
                }
                else if (!(bool)memberValue)
                    controlWord = string.Empty;
            }

            return controlWord;
        }

        private string GetEnumControlWord(Type memberType, object memberValue, string attributeControlWord)
        {
            var info = _rtfDocumentInfo.GetAttributeInfo(memberType);
            
            if (memberType == null)
                throw (new ArgumentNullException(@"memberType", @"MemberType cannot be null"));

            if (!memberType.IsEnum)
                throw (new ArgumentException(@"MemberType must be an enum", @"memberType"));

            if (info.EnumAsControlWordAttribute == null)
                return string.Empty;

            var controlWord = @"\";

            if (!string.IsNullOrEmpty(attributeControlWord))
                controlWord += attributeControlWord;
            else
                controlWord += info.EnumAsControlWordAttribute.Prefix;

            switch (info.EnumAsControlWordAttribute.Conversion)
            {
                case EEnumConversion.UseAttribute:
                    {
                        var enumMember = memberType.GetMember(((Enum)memberValue).ToString());

                        if (enumMember.Length > 0)
                        {
                            var enumMemberInfo = _rtfDocumentInfo.GetAttributeInfo(enumMember[0]);

                            if (enumMemberInfo.RtfControlWordAttribute != null)
                                controlWord += enumMemberInfo.RtfControlWordAttribute.Name;
                        }
                        break;
                    }
                case EEnumConversion.UseValue:
                    {
                        if (memberValue == null)
                            throw (new ArgumentNullException(string.Format("Type {0} cannot take null as a value", memberType.Name)));

                        controlWord += ((int)memberValue).ToString();
                        break;
                    }
                case EEnumConversion.UseName:
                    {
                        controlWord += ((Enum)memberValue).ToString().ToLower();
                        break;
                    }
                default:
                    // ReSharper disable once NotResolvedInText
                    throw new ArgumentOutOfRangeException(@"info.EnumAsControlWordAttribute.Conversion", @"Invalid value");
            }

            return controlWord;
        }
        
        private bool GetCondition(object instance, RtfIncludeAttribute includeAttribute)
        {
            if (string.IsNullOrEmpty(includeAttribute.ConditionMember))
                return true;

            var type = instance.GetType();
            var memberInfo = type.GetMember(includeAttribute.ConditionMember);

            if (memberInfo.Length == 1)
            {
                var member = memberInfo[0];
                
                if (member.MemberType == MemberTypes.Property || member.MemberType == MemberTypes.Field)
                    return (GetMemberType(member) == typeof(bool)) && (includeAttribute.Value == (bool)GetMemberValue(member, instance));
            }

            return false;
        }

        private bool TypeIsIEnumerable(Type memberType)
        {
            var isEnumerable = false;
            var interfaceTypes = memberType.GetInterfaces();

            for (var i = 0; !isEnumerable && i < interfaceTypes.Length; i++)
                isEnumerable = interfaceTypes[i] == typeof(System.Collections.IEnumerable);

            return isEnumerable;
        }
        
        private Type GetMemberType(MemberInfo member)
        {
            Type memberType;

            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    var field = member as FieldInfo;
                    // ReSharper disable once PossibleNullReferenceException
                    memberType = field.FieldType;
                    break;
                case MemberTypes.Property:
                    var property = member as PropertyInfo;
                    // ReSharper disable once PossibleNullReferenceException
                    memberType = property.PropertyType;
                    break;
                default:
                    throw (new ArgumentException(@"Method cannot take members other than fields and properties as arguments"));
            }

            return memberType;
        }

        private object GetMemberValue(MemberInfo member, object instance)
        {
            object value;

            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    var field = member as FieldInfo;
                    // ReSharper disable once PossibleNullReferenceException
                    value = field.GetValue(instance);
                    break;
                case MemberTypes.Property:
                    var property = member as PropertyInfo;
                    // ReSharper disable once PossibleNullReferenceException
                    value = property.GetValue(instance, null);
                    break;
                default:
                    throw (new ArgumentException("Method cannot take members other than fields and properties as arguments"));
            }

            return value;
        }
        
        private string EncodeText(string text, RtfTextDataType type)
        {
            if (type == RtfTextDataType.Raw)
            {
                return text;
            }

            if (type == RtfTextDataType.HyperLink)
            {
                return Uri.EscapeUriString(text);
            }

            var encodedText = new StringBuilder();

            var data = _encoding.GetBytes(text);

            for (var i = 0; i < data.Length; i++)
            {
                if (text[i] == Encoding.ASCII.GetChars(data, i, 1)[0])
                {
                    if (text[i] == '\\' || text[i] == '{' || text[i] == '}')
                        encodedText.Append('\\');

                    encodedText.Append(text[i]);
                }
                else if (text[i] == _encoding.GetChars(data, i, 1)[0])
                {
                    encodedText.Append('\\').Append('\'').Append(Convert.ToString(data[i], 16));
                }
                else
                {                    
                    var unicode = Encoding.Unicode.GetBytes(text[i].ToString());
                    encodedText.Append('\\').Append('u').Append(BitConverter.ToUInt16(unicode, 0).ToString()).Append('?');
                }


                if (_stringBuilder.Length + encodedText.Length - _lastNewLineIndex > PreferredWidth)
                {
                    encodedText.AppendLine();
                    _lastNewLineIndex = _stringBuilder.Length + encodedText.Length;
                }
            }

            return encodedText.ToString();
        }
        
        private void Append(char value)
        {
            if (value == '\\' && (_stringBuilder.Length - _lastNewLineIndex > PreferredWidth))
                AppendLine();
            
            _stringBuilder.Append(value);
        }

        private void Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value[0] == '\\' && (_stringBuilder.Length - _lastNewLineIndex > PreferredWidth))
                    AppendLine();
                else if (_stringBuilder.Length - _lastNewLineIndex + value.Length > PreferredWidth)
                    AppendLine();
            }

            _stringBuilder.Append(value);
        }

        private void AppendLine()
        {            
            if (_lastNewLineIndex != _stringBuilder.Length)
            {
                _stringBuilder.AppendLine();
                
                _lastNewLineIndex = _stringBuilder.Length;
            }
        }
        #endregion
    }
}