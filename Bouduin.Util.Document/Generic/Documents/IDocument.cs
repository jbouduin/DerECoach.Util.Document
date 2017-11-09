using System.Collections.ObjectModel;
using System.Drawing;
using Bouduin.Util.Document.Generic.Header;

namespace Bouduin.Util.Document.Generic.Documents
{
    public interface IDocument
    {

        int AddFont(string fontName);
        int AddFont(string fontName, ECharacterSet characterSet);
        int AddFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily);
        int AddFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily, EFontPitch fontPitch);

        int AddColor(Color color);
        int AddColor(int red, int green, int blue);

        ELanguage DefaultLanguage { get; set; }

        void AddContent(params IDocumentContent[] documentContents);
        void InsertContent(int index, params IDocumentContent[] documentContents);
    }

    internal interface IDocumentInternal : IDocument
    {
        ReadOnlyCollection<IDocumentContent> DocumentContentsInternal { get; }
    }
}