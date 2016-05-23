namespace Bouduin.Util.Document.Generic.Header
{
    internal interface IDocumentFont
    {
        EFontFamily FontFamily { get; }
        ECharacterSet CharacterSet { get; }
        EFontPitch Pitch { get; }
        string FontName { get; }
        bool Equals(object obj);
        int GetHashCode();
    }
}