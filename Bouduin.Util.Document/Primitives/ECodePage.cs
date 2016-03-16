using Bouduin.Util.Document.Rtf.Attributes;

// ReSharper disable InconsistentNaming

namespace Bouduin.Util.Document.Primitives
{
    /// <summary>
    /// Specifies codepage.
    /// </summary>
    [RtfEnumAsControlWord(RtfEnumConversion.UseValue, Prefix = "ansicpg")]
    public enum ECodePage
    {
        IBM = 437,
        Arabic708 = 708,
        Arabic709 = 709,
        Arabic710 = 710,
        Arabic711 = 711,
        Arabic720 = 720,
        Windows819 = 819,
        EasternEuropean = 852,
        Portuguese = 860,
        Hebrew862 = 862,
        FrenchCanadian = 863,
        Arabic864 = 864,
        Norwegian = 865,
        SovietUnion = 866,
        Thai = 874,
        Japanese = 932,
        SimplifiedChinese = 936,
        Korean = 949,
        TraditionalChinese = 950,
        Windows1250 = 1250,
        Windows1251 = 1251,
        WesternEuropean = 1252,
        Greek = 1253,
        Turkish = 1254,
        Hebrew1255 = 1255,
        Arabic1256 = 1256,
        Baltic = 1257,
        Vietnamese = 1258,
        Johab = 1361,
    }
}