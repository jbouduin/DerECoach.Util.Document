using System.Drawing;
using Bouduin.Util.Document.Generic.Contents.Image;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document
{
    // TODO extract Interface
    public class Factory
    {
        #region IDocument -----------------------------------------------------

        public static IDocument CreateDocument()
        {
            return new Generic.Document.Document();
        }

        public static IDocument CreateDocument(ECodePage codePage)
        {
            return new Generic.Document.Document(codePage);
        }

        #endregion

        #region IFormattedParagraph -------------------------------------------

        public static IFormattedParagraph CreateFormattedParagraph()
        {
            return new FormattedParagraph();
        }

        /// <param name="align"></param>
        /// <returns></returns>
        public static IFormattedParagraph CreateFormattedParagraph(ETextAlign align)
        {
            return new FormattedParagraph(align);
        }

        /// <param name="fontSize"></param>
        /// <returns></returns>
        public static IFormattedParagraph CreateFormattedParagraph(float fontSize)
        {
            return new FormattedParagraph(fontSize);
        }

        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public static IFormattedParagraph CreateFormattedParagraph(float fontSize, ETextAlign align)
        {
            return new FormattedParagraph(fontSize, align);
        }
        #endregion

        #region IFormattedText ------------------------------------------------

        public static IFormattedText CreateFormattedText(string text = null)
        {
            return new FormattedText(text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        public static IFormattedText CreateFormattedText(int colorIndex, string text = null)
        {
            return new FormattedText(colorIndex, text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="formatting">Character formatting to apply to the text.</param>
        public static IFormattedText CreateFormattedText(ECharacterFormatting formatting, string text = null)
        {
            return new FormattedText(formatting, text);
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        /// <param name="text">String value to set as text.</param>
        public static IFormattedText CreateFormattedText(ECharacterFormatting formatting, int colorIndex,
            string text = null)
        {
            return new FormattedText(formatting, colorIndex, text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        public static IFormattedText CreateFormattedText(int fontIndex, float fontSize, string text = null)

        {
            return new FormattedText(fontIndex, fontSize, text);
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        /// <param name="text">String value to set as text.</param>
        public static IFormattedText CreateFormattedText(
            ECharacterFormatting formatting, 
            int fontIndex, 
            float fontSize,
            string text = null)
        {
            return new FormattedText(formatting, fontIndex, fontSize, text);
        }

        #endregion

        #region IDocumentImage ------------------------------------------------
        public static IDocumentImage CreateDocumentImage(Bitmap bitmap)
        {
            return new DocumentImage(bitmap);
        }

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        public static IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format)
        {
            return new DocumentImage(bitmap, format);
        }

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        public static IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY)
        {
            return new DocumentImage(bitmap, format, dpiX, dpiY);
        }
        #endregion

        #region IHyperlink ----------------------------------------------------

        public static IHyperlink CreateHyperlink(string address, IFormattedText text)
        {
            return new Hyperlink(address, text);
        }
        #endregion

        #region special characters --------------------------------------------

        public static ITabCharacter CreateTabCharacter()
        {
            return new TabCharacter();
        }
        #endregion

        #region ITab ----------------------------------------------------------
        /// <param name="position">Tab position in twips</param>
        public static ITab CreateTab(int position)
        {
            return new Tab(position);
        }

        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        public static ITab CreateTab(int position, ETabKind kind)
        {
            return new Tab(position, kind);
        }

        /// <param name="position">Tab position in twips</param>
        /// <param name="lead">Tab lead</param>
        public static ITab CreateTab(int position, ETabLead lead)
        {
            return new Tab(position, lead);
        }

        
        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        /// <param name="lead">Tab lead</param>
        public static ITab CreateTab(int position, ETabKind kind, ETabLead lead)
        {
            return new Tab(position, kind, lead);
        }
        #endregion
    }
}