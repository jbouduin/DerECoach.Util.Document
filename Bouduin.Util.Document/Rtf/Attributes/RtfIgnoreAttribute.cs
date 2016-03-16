using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies that RtfWriter must ignore a member of a class
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfIgnoreAttribute : Attribute
    {
    }
}