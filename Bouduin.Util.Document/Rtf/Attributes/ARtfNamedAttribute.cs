using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    internal abstract class ARtfNamedAttribute: Attribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets the attribute name propertiy.
        /// </summary>
        internal string Name { get; private set; }
        #endregion

        #region constructor ---------------------------------------------------
        protected ARtfNamedAttribute(): this(string.Empty)
        {
            
        }

        protected ARtfNamedAttribute(string name)
        {
            Name = name;
        }
        #endregion
    }
}