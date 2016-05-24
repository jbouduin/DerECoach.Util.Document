using System.Drawing;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Image;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Generic
{
    public interface IFactory
    {
        IDocument CreateDocument();
        IDocument CreateDocument(ECodePage codePage);
        IFormattedParagraph CreateFormattedParagraph();

        /// <param name="align"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(ETextAlign align);

        /// <param name="fontSize"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(float fontSize);

        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(float fontSize, ETextAlign align);

        IFormattedText CreateFormattedText(string text = null);

        /// <param name="text">String value to set as text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        IFormattedText CreateFormattedText(int colorIndex, string text = null);

        /// <param name="text">String value to set as text.</param>
        /// <param name="formatting">Character formatting to apply to the text.</param>
        IFormattedText CreateFormattedText(ECharacterFormatting formatting, string text = null);

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        /// <param name="text">String value to set as text.</param>
        IFormattedText CreateFormattedText(ECharacterFormatting formatting, int colorIndex,
            string text = null);

        /// <param name="text">String value to set as text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        IFormattedText CreateFormattedText(int fontIndex, float fontSize, string text = null);

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        /// <param name="text">String value to set as text.</param>
        IFormattedText CreateFormattedText(
            ECharacterFormatting formatting, 
            int fontIndex, 
            float fontSize,
            string text = null);

        IDocumentImage CreateDocumentImage(Bitmap bitmap);

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format);

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY);

        IHyperlink CreateHyperlink(string address, IFormattedText text);
        ITabCharacter CreateTabCharacter();
        ITwipConverter CreateTwipConverter();

        /// <param name="position">Tab position in twips</param>
        ITab CreateTab(int position);

        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        ITab CreateTab(int position, ETabKind kind);

        /// <param name="position">Tab position in twips</param>
        /// <param name="lead">Tab lead</param>
        ITab CreateTab(int position, ETabLead lead);

        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        /// <param name="lead">Tab lead</param>
        ITab CreateTab(int position, ETabKind kind, ETabLead lead);
    }
}