using System;
using System.IO;
using System.Reflection;
using System.Text;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Rtf.Document
{
    /// <summary>
    /// Reflects ESCommon.Rtf.RtfDocument generating an RTF string which is written to a file.
    /// </summary>
    public class RtfWriter
    {
        private const int preferredWidth = 128;

        private StringBuilder sb;
        private Encoding _encoding;
        private int lastNewLineIndex;
        

        /// <summary>
        /// Writes ESCommon.Rtf.RtfDocument to a file.
        /// </summary>
        /// <param name="writer">The System.IO.TextWriter used to write RTF document.</param>
        /// <param name="document">The ESCommon.Rtf.RtfDocument to write.</param>
        public void Write(TextWriter writer, IDocument document)
        {
            var doc = document as RtfDocument;
            _encoding = Encoding.GetEncoding((int)doc.CodePage);
            
            sb = new StringBuilder();

            Reflect(doc);

            writer.Write(sb.ToString());
        }


        private void Reflect(object instance)
        {
            Reflect(instance, -1);
        }

        private void Reflect(object instance, int arrayIndex)
        {
            var type = instance.GetType();

            var info = RtfDocumentInfo.GetAttributeInfo(type);

            string
                controlWord = info.ControlWordAttribute != null ? "\\" + info.ControlWordAttribute.Name : string.Empty,
                controlWordDenotingEnd = info.ControlWordDenotingEndAttribute != null ? "\\" + info.ControlWordDenotingEndAttribute.Name : string.Empty;

            bool
                isIndexed = info.ControlWordAttribute != null && info.ControlWordAttribute.IsIndexed,
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

            var members = RtfDocumentInfo.GetTypeMembers(type);

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
            var info = RtfDocumentInfo.GetAttributeInfo(member);

            if (!info.HasAttributes)
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

            if (info.ControlWordAttribute != null)
            {
                Append(GetControlWord(member, memberType, value, info.ControlWordAttribute.Name));

                if (memberType.IsClass)
                {
                    if (TypeIsEnumerable(memberType))
                        ReflectArray(memberType, value);
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

            if (info.ControlGroupAttribute != null)
            {
                AppendLine();
                Append('{');
                Append('\\');
                Append(info.ControlGroupAttribute.Name);
                Append(' ');

                ReflectArray(memberType, value);

                Append('}');
                AppendLine();

                return;
            }

            if (info.IncludeAttribute != null && memberType.IsClass)
            {
                if (TypeIsEnumerable(memberType))
                    ReflectArray(memberType, value);
                else if (value != null)
                    Reflect(value);
            }
        }

        private void ReflectArray(Type memberType, object value)
        {
            if (memberType == null)
                throw (new ArgumentNullException("Type cannot be null"));
            
            var array = value as System.Collections.IEnumerable;
            
            var index = 0;

            if (array != null)
            {
                foreach (var arrayMember in array)
                    Reflect(arrayMember, index++);
            }
        }


        private object GetAttribute(object[] attributes, Type type)
        {
            foreach (var attribute in attributes)
                if (attribute.GetType() == type)
                    return attribute;
            
            return null;
        }


        private string GetControlWord(MemberInfo member, Type memberType, object memberValue, string attributeControlWord)
        {
            if (memberType == null)
                throw (new ArgumentNullException("Type cannot be null"));

            var controlWord = string.Empty;

            if (memberType.IsEnum)
                controlWord = GetEnumControlWord(member, memberType, memberValue, attributeControlWord);
            else
                controlWord = GetMemberControlWord(member, memberType, memberValue, attributeControlWord);

            if (controlWord == "\\")
            {
                return string.Empty;
            }

            return controlWord;
        }

        private string GetMemberControlWord(MemberInfo member, Type memberType, object memberValue, string attributeControlWord)
        {
            if (memberType == null)
                throw (new ArgumentNullException("Type cannot be null"));

            if (memberType.IsEnum)
                throw (new ArgumentException("Type cannot be enum"));

            var controlWord = "\\";
            
            if (!string.IsNullOrEmpty(attributeControlWord))
                controlWord += attributeControlWord;
            else
                controlWord += member.Name.ToLower();

            if (memberType.IsPrimitive)
            {
                if (memberType == typeof(int))
                {
                    var info = RtfDocumentInfo.GetAttributeInfo(member);

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

        private string GetEnumControlWord(MemberInfo member, Type memberType, object memberValue, string attributeControlWord)
        {
            var info = RtfDocumentInfo.GetAttributeInfo(memberType);
            
            if (memberType == null)
                throw (new ArgumentNullException("Type cannot be null"));

            if (!memberType.IsEnum)
                throw (new ArgumentException("Type cannot be enum"));

            if (info.EnumAsControlWordAttribute == null)
                return string.Empty;

            var controlWord = "\\";

            if (!string.IsNullOrEmpty(attributeControlWord))
                controlWord += attributeControlWord;
            else
                controlWord += info.EnumAsControlWordAttribute.Prefix;

            switch (info.EnumAsControlWordAttribute.Conversion)
            {
                case RtfEnumConversion.UseAttribute:
                    {
                        var enumMember = memberType.GetMember(((Enum)memberValue).ToString());

                        if (enumMember != null && enumMember.Length > 0)
                        {
                            var enumMemberInfo = RtfDocumentInfo.GetAttributeInfo(enumMember[0]);

                            if (enumMemberInfo.ControlWordAttribute != null)
                                controlWord += enumMemberInfo.ControlWordAttribute.Name;
                        }
                        break;
                    }
                case RtfEnumConversion.UseValue:
                    {
                        if (memberValue == null)
                            throw (new ArgumentNullException(string.Format("Type {0} cannot take null as a value", memberType.Name)));

                        controlWord += ((int)memberValue).ToString();
                        break;
                    }
                case RtfEnumConversion.UseName:
                default:
                    {
                        controlWord += ((Enum)memberValue).ToString().ToLower();
                        break;
                    }
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

        private bool TypeIsEnumerable(Type memberType)
        {
            var IsEnumerable = false;
            var interfaceTypes = memberType.GetInterfaces();

            for (var i = 0; !IsEnumerable && i < interfaceTypes.Length; i++)
                IsEnumerable = interfaceTypes[i] == typeof(System.Collections.IEnumerable);

            return IsEnumerable;
        }


        private Type GetMemberType(MemberInfo member)
        {
            Type memberType = null;

            if (member.MemberType == MemberTypes.Field)
            {
                var field = member as FieldInfo;
                memberType = field.FieldType;
            }
            else if (member.MemberType == MemberTypes.Property)
            {
                var property = member as PropertyInfo;
                memberType = property.PropertyType;
            }
            else
                throw (new ArgumentException("Method cannot take members other than fields and properties as arguments"));

            return memberType;
        }

        private object GetMemberValue(MemberInfo member, object instance)
        {
            object value = null;

            if (member.MemberType == MemberTypes.Field)
            {
                var field = member as FieldInfo;
                value = field.GetValue(instance);
            }
            else if (member.MemberType == MemberTypes.Property)
            {
                var property = member as PropertyInfo;
                value = property.GetValue(instance, null);
            }
            else
                throw (new ArgumentException("Method cannot take members other than fields and properties as arguments"));

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


                if (sb.Length + encodedText.Length - lastNewLineIndex > preferredWidth)
                {
                    encodedText.AppendLine();
                    lastNewLineIndex = sb.Length + encodedText.Length;
                }
            }

            return encodedText.ToString();
        }

        
        private void Append(char value)
        {
            if (value == '\\' && (sb.Length - lastNewLineIndex > preferredWidth))
                AppendLine();
            
            sb.Append(value);
        }

        private void Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value[0] == '\\' && (sb.Length - lastNewLineIndex > preferredWidth))
                    AppendLine();
                else if (sb.Length - lastNewLineIndex + value.Length > preferredWidth)
                    AppendLine();
            }

            sb.Append(value);
        }

        private void AppendLine()
        {            
            if (lastNewLineIndex != sb.Length)
            {
                sb.AppendLine();
                
                lastNewLineIndex = sb.Length;
            }
        }
    }
}