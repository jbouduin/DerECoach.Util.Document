using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control characters used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class RtfEnclosingBracesAttribute : Attribute
    {
        #region fields --------------------------------------------------------
        private bool _braces = true;
        #endregion

        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets or sets a Boolean value indicating whether RtfWriter should enclose a class with braces.
        /// </summary>
        public bool Braces
        {
            get { return _braces; }
            set { _braces = value; }
        }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether RtfWriter should add a semicolon after reflecting a class.
        /// </summary>
        public bool ClosingSemicolon { get; set; }

        #endregion
    }
}