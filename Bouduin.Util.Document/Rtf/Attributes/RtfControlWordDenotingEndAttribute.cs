using System;

namespace Bouduin.Util.Document.Rtf.Attributes
{
    /// <summary>
    /// Specifies control word which is added to RTF document after RtfWriter reflects all the members of a class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    internal class RtfControlWordDenotingEndAttribute : ARtfNamedAttribute
    {

        internal RtfControlWordDenotingEndAttribute(string name):base(name)
        {
        }
    }
}