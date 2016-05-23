using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Can be used to specify the order in which the members are written to the result
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfSortIndexAttribute: Attribute
    {
        #region properties ----------------------------------------------------
        public int SortIndex { get; set; }
        #endregion

        #region constructor ---------------------------------------------------

        public RtfSortIndexAttribute(int sortIndex)
        {
            SortIndex = sortIndex;
        }
        #endregion
    }
}