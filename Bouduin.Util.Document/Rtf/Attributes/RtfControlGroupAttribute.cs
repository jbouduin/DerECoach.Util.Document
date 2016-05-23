using System;
using Bouduin.Util.Document.Generic.Attributes;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control group.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfControlGroupAttribute : ANamedAttribute
    {
        #region constructor ---------------------------------------------------
        internal RtfControlGroupAttribute()
        {
            
        }

        internal RtfControlGroupAttribute(string name): base(name)
        {

        }
        #endregion
    }
}