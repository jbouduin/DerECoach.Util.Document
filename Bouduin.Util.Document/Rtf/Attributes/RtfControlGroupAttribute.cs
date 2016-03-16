using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control group.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfControlGroupAttribute : ARtfNamedAttribute
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