using System.Collections.ObjectModel;
using System.Drawing;
using Bouduin.Util.Document.Generic.Header;

namespace Bouduin.Util.Document.Generic.Document
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

        // TODO hide the colleciton itself and use an add and an addrange method
        // eventually indexed
        ObservableCollection<IDocumentContent> Contents { get; }
    }
}