using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Image
{
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum EImageFormat
    {
        [RtfControlWord("pngblip")]
        Png,
        [RtfControlWord("jpegblip")]
        Jpeg,
        [RtfControlWord("wmetafile8")]
        Wmf,
    }
}