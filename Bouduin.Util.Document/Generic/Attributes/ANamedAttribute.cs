using System;

namespace Bouduin.Util.Document.Generic.Attributes
{
    internal abstract class ANamedAttribute: Attribute
    {
        #region properties ----------------------------------------------------
        /// <summary>
        /// Gets the attribute name propertiy.
        /// </summary>
        internal string Name { get; private set; }
        #endregion

        #region constructor ---------------------------------------------------
        protected ANamedAttribute(): this(string.Empty)
        {
            
        }

        protected ANamedAttribute(string name)
        {
            Name = name;
        }
        #endregion
    }
}