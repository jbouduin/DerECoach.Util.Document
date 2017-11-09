using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Rtf.Document
{
    
    internal class RtfAttributeInfo: AAttributeInfo
    {
        #region properties ----------------------------------------------------
        public RtfControlWordAttribute RtfControlWordAttribute
        {
            get { return GetAttribute<RtfControlWordAttribute>(); }
        }

        public RtfControlGroupAttribute RtfControlGroupAttribute
        {
            get { return GetAttribute<RtfControlGroupAttribute>(); }
        }

        public RtfControlWordDenotingEndAttribute RtfControlWordDenotingEndAttribute
        {
            get { return GetAttribute<RtfControlWordDenotingEndAttribute>(); }
        }

        public RtfEnclosingBracesAttribute EnclosingBracesAttribute
        {
            get { return GetAttribute<RtfEnclosingBracesAttribute>(); }
        }

        public RtfIgnoreAttribute IgnoreAttribute
        {
            get { return GetAttribute<RtfIgnoreAttribute>(); }
        }

        public RtfIncludeAttribute IncludeAttribute
        {
            get { return GetAttribute<RtfIncludeAttribute>(); }
        }

        public RtfIndexAttribute IndexAttribute
        {
            get { return GetAttribute<RtfIndexAttribute>(); }
        }

        public RtfEnumAsControlWordAttribute EnumAsControlWordAttribute
        {
            get { return GetAttribute<RtfEnumAsControlWordAttribute>(); }
        }

        public RtfTextDataAttribute TextDataAttribute
        {
            get { return GetAttribute<RtfTextDataAttribute>(); }
        }
        #endregion

       
        
    }
}