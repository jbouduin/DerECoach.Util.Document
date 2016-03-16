using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies wheter RtfWriter must include a member according to condition.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfIncludeAttribute : Attribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets or sets name of a Boolean member inside a class, value of which is used by RtfWriter as a condition. 
        /// </summary>
        public string ConditionMember { get; set; }

        /// <summary>
        /// Gets or sets value of the condition member. Default is true.
        /// </summary>
        public bool Value { get; set; }
        #endregion

        #region constructor ---------------------------------------------------
        public RtfIncludeAttribute()
        {
            Value = true;
        }
        #endregion
    }
}