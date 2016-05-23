using System;
using Bouduin.Util.Document.Generic.Attributes;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control word which is added to RTF document after RtfWriter reflects all the members of a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfControlWordDenotingEndAttribute : ANamedAttribute
    {

        internal RtfControlWordDenotingEndAttribute(string name):base(name)
        {
        }
    }
}