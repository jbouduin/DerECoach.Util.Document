using System.Reflection;

namespace Bouduin.Util.Document.Generic.Document
{
    internal abstract class ATypeInfo<TAttributeInfo> : ATypeInfo
        where TAttributeInfo : AAttributeInfo, new() 
    {
        
        #region properties ----------------------------------------------------
        internal IADocumentInfo<TAttributeInfo> DocumentInfo { get; set; } 
        #endregion

        protected override bool FilterHasAttributes(MemberInfo m, object filterCriteria)
        {
            var info = DocumentInfo.GetAttributeInfo(m);
            return info.HasAnyRelevantAttribute;
        }
        

        
    }
}