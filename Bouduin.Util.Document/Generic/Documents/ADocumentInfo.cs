using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bouduin.Util.Document.Generic.Documents
{
    internal interface IADocumentInfo<out TAttributeInfo> where TAttributeInfo : AAttributeInfo, new() 
    {
        TAttributeInfo GetAttributeInfo(MemberInfo memberInfo);
        IList<MemberInfo> GetTypeMembers(Type type);
    }

    internal abstract class ADocumentInfo<TAttributeInfo, TTypeInfo> : IADocumentInfo<TAttributeInfo>
        where TAttributeInfo : AAttributeInfo, new()
        where TTypeInfo : ATypeInfo<TAttributeInfo>, new()
    {
        #region properties ----------------------------------------------------

        private readonly IList<TAttributeInfo> _attributeInfoItems = new List<TAttributeInfo>();
        private readonly IList<TTypeInfo> _typeInfoItems = new List<TTypeInfo>();

        #endregion

        #region IADocumentInfo members ----------------------------------------

        public TAttributeInfo GetAttributeInfo(MemberInfo memberInfo)
        {
            var info = _attributeInfoItems.FirstOrDefault(item => item.MemberInfo == memberInfo) ??
                       new TAttributeInfo {MemberInfo = memberInfo};
            _attributeInfoItems.Add(info);

            return info;
        }

        public IList<MemberInfo> GetTypeMembers(Type type)
        {
            // Important: when creating assign Document Info before assigning Type
            // TODO: change the setters of these 2 properties so the order becomes unimportant
            var info = _typeInfoItems.FirstOrDefault(item => item.Type == type) ??
                       new TTypeInfo { DocumentInfo = this, Type = type };
            _typeInfoItems.Add(info);

            return info.Members;
        }

        #endregion
    }
}