using System;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    /// <summary>
    /// Specifies font (character) formatting.
    /// </summary>
    [Flags]
    public enum ECharacterFormatting
    {
        Regular = 0,
        Bold = 1,
        Italic = 2,
        Underline = 4,
        Subscript = 8,
        Superscript = 16,
        Caps = 32,
        SmallCaps = 64
    }
}