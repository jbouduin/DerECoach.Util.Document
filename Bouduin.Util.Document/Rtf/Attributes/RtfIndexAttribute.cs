using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies that a member is an index and must be ignored if value is negative.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfIndexAttribute : Attribute
    {
    }
}