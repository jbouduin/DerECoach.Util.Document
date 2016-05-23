using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Specifies border style.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseAttribute)]
    public enum EBorderStyle
    {
        [RtfControlWord("brdrs")]
        SingleThicknessBorder,
        [RtfControlWord("brdrth")]
        DoubleThicknessBorder,
        [RtfControlWord("brdrsh")]
        ShadowedBorder,
        [RtfControlWord("brdrdb")]
        DoubleBorder,
        [RtfControlWord("brdrdot")]
        DottedBorder,
        [RtfControlWord("brdrdash")]
        DashedBorder,
        [RtfControlWord("brdrhair")]
        HairlineBorder,
        [RtfControlWord("brdrinset")]
        InsetBorder,
        [RtfControlWord("brdrdashsm")]
        DashedBorderSmall,
        [RtfControlWord("brdrdashd")]
        DotDashedBorder,
        [RtfControlWord("brdrdashdd")]
        DotDotDashedBorder,
        [RtfControlWord("brdroutset")]
        OutsetBorder,
        [RtfControlWord("brdrtriple")]
        TripleBorder,
        [RtfControlWord("brdrtnthsg")]
        ThickThinBorderSmall,
        [RtfControlWord("brdrthtnsg")]
        ThinThickBorderSmall,
        [RtfControlWord("brdrtnthtnsg")]
        ThinThickThinBorderSmall,
        [RtfControlWord("brdrtnthmg")]
        ThickThinBorderMedium,
        [RtfControlWord("brdrthtnmg")]
        ThinThickBorderMedium,
        [RtfControlWord("brdrtnthtnmg")]
        ThinThickThinBorderMedium,
        [RtfControlWord("brdrtnthlg")]
        ThickThinBorderLarge,
        [RtfControlWord("brdrthtnlg")]
        ThinThickBorderLarge,
        [RtfControlWord("brdrtnthtnlg")]
        ThinThickThinBorderLarge,
        [RtfControlWord("brdrwavy")]
        WavyBorder,
        [RtfControlWord("brdrwavydb")]
        DoubleWavyBorder,
        [RtfControlWord("brdrdashdotstr")]
        StripedBorder,
        [RtfControlWord("brdremboss")]
        EmbossedBorder,
        [RtfControlWord("brdrengrave")]
        EngravedBorder,
        [RtfControlWord("brdrframe")]
        FrameBorder
    }
}