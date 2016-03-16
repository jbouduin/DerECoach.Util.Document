using System;
using System.Collections;
using System.Reflection;

namespace Bouduin.Util.Document.Rtf.Document
{
    internal static class RtfDocumentInfo
    {
        private static readonly ArrayList 
            attributeInfoItems = new ArrayList();

        private static readonly ArrayList 
            typeInfoItems = new ArrayList();

        internal static RtfAttributeInfo GetAttributeInfo(MemberInfo memberInfo)
        {
            foreach (RtfAttributeInfo item in attributeInfoItems)
                if (item.MemberInfo == memberInfo)
                    return item;

            var info = new RtfAttributeInfo(memberInfo);
            attributeInfoItems.Add(info);

            return info;
        }

        internal static MemberInfo[] GetTypeMembers(Type type)
        {
            foreach (RtfTypeInfo item in typeInfoItems)
                if (item.Type == type)
                    return item.Members;
            
            var info = new RtfTypeInfo(type);
            typeInfoItems.Add(info);

            return info.Members;
        }
    }
}