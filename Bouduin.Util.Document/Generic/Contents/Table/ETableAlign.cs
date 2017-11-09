using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table
{
    /// <summary>
    /// Defines table align
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum ETableAlign
    {
        [RtfControlWord("trql")] Left,
        [RtfControlWord("trqc")] Center,
        [RtfControlWord("trqr")] Right
    }
}