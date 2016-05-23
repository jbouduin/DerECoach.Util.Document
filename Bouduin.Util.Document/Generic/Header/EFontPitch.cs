using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Header
{
    /// <summary>
    /// Specifies font pitch.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseValue, Prefix = "fprq")]
    public enum EFontPitch
    {
        Default,
        Fixed,
        Variable
    }
}