using System;
using Bouduin.Util.Document.Generic.Attributes;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control word.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfControlWordAttribute : ANamedAttribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets or sets a Boolean value indicating wheter the control word should be indexed when RtfWriter reflects an array.
        /// </summary>
        public bool IsIndexed { get; set; }
        #endregion

        #region constructor ---------------------------------------------------
        internal RtfControlWordAttribute()
        {
            
        }
        
        internal RtfControlWordAttribute(string name):base(name)
        {

        }
        #endregion
    }
}