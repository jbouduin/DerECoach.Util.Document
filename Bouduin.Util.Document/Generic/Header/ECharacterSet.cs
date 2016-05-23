using Bouduin.Util.Document.Generic.Attributes;
using Bouduin.Util.Document.Rtf.Attributes;
// ReSharper disable InconsistentNaming

namespace Bouduin.Util.Document.Generic.Header
{
    /// <summary>
    /// Specifies character set.
    /// </summary>
    [RtfEnumAsControlWord(EEnumConversion.UseValue, Prefix = "fcharset")]
    public enum ECharacterSet
    {
        ANSI = 0,
        Default = 1,
        Symbol = 2,
        Invalid = 3,
        Mac = 77,
        ShiftJis = 128,
        Hangul = 129,
        Johab = 130,
        GB2312 = 134,
        Big5 = 136,
        Greek = 161,
        Turkish = 162,
        Vietnamese = 163,
        Hebrew = 177,
        Arabic = 178,
        ArabicTraditional = 179,
        ArabicUser = 180,
        HebrewUser = 181,
        Baltic = 186,
        Russian = 204,
        Thai = 222,
        EasternEuropean = 238,
        PC437 = 254,
        OEM = 255,
    }
}