using System;
using System.Reflection;

namespace Bouduin.Util.Document.Rtf.Document
{
    internal class RtfTypeInfo
    {
        private readonly Type _type;

        private readonly MemberInfo[] _members;

        internal Type Type
        {
            get { return _type; }
        }

        internal MemberInfo[] Members
        {
            get { return _members; }
        }

        internal RtfTypeInfo(Type type)
        {
            _type = type;
            _members = _type.FindMembers(MemberTypes.Field | MemberTypes.Property,
                BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, FilterHasAttributes, null);
        }

        private bool FilterHasAttributes(MemberInfo m, object filterCriteria)
        {
            var info = RtfDocumentInfo.GetAttributeInfo(m);
            return info.HasAttributes;
        }
    }
}