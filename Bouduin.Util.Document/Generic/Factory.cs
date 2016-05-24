using System.Drawing;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Image;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Generic
{
    internal class Factory : IFactory
    {
        #region IDocument -----------------------------------------------------

        public IDocument CreateDocument()
        {
            return new Generic.Document.Document();
        }

        public IDocument CreateDocument(ECodePage codePage)
        {
            return new Generic.Document.Document(codePage);
        }

        #endregion

        #region IFormattedParagraph -------------------------------------------

        public IFormattedParagraph CreateFormattedParagraph()
        {
            return new FormattedParagraph(new TwipConverter());
        }

        /// <param name="align"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(ETextAlign align)
        {
            return new FormattedParagraph(new TwipConverter(), align);
        }

        /// <param name="fontSize"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(float fontSize)
        {
            return new FormattedParagraph(new TwipConverter(), fontSize);
        }

        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(float fontSize, ETextAlign align)
        {
            return new FormattedParagraph(new TwipConverter(), fontSize, align);
        }
        #endregion

        #region IFormattedText ------------------------------------------------

        public IFormattedText CreateFormattedText(string text = null)
        {
            return new FormattedText(text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        public IFormattedText CreateFormattedText(int colorIndex, string text = null)
        {
            return new FormattedText(colorIndex, text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="formatting">Character formatting to apply to the text.</param>
        public IFormattedText CreateFormattedText(ECharacterFormatting formatting, string text = null)
        {
            return new FormattedText(formatting, text);
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        /// <param name="text">String value to set as text.</param>
        public IFormattedText CreateFormattedText(ECharacterFormatting formatting, int colorIndex,
            string text = null)
        {
            return new FormattedText(formatting, colorIndex, text);
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        public IFormattedText CreateFormattedText(int fontIndex, float fontSize, string text = null)

        {
            return new FormattedText(fontIndex, fontSize, text);
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        /// <param name="text">String value to set as text.</param>
        public IFormattedText CreateFormattedText(
            ECharacterFormatting formatting, 
            int fontIndex, 
            float fontSize,
            string text = null)
        {
            return new FormattedText(formatting, fontIndex, fontSize, text);
        }

        #endregion

        #region IDocumentImage ------------------------------------------------
        public IDocumentImage CreateDocumentImage(Bitmap bitmap)
        {
            return new DocumentImage(new TwipConverter(), bitmap);
        }

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        public IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format)
        {
            return new DocumentImage(new TwipConverter(), bitmap, format);
        }

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        public IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY)
        {
            return new DocumentImage(new TwipConverter(), bitmap, format, dpiX, dpiY);
        }
        #endregion

        #region IHyperlink ----------------------------------------------------

        public IHyperlink CreateHyperlink(string address, IFormattedText text)
        {
            return new Hyperlink(address, text);
        }
        #endregion

        #region special characters --------------------------------------------

        public ITabCharacter CreateTabCharacter()
        {
            return new TabCharacter();
        }
        #endregion

        #region utilities -----------------------------------------------------

        public ITwipConverter CreateTwipConverter()
        {
            return new TwipConverter();
        }
        #endregion

        #region ITab ----------------------------------------------------------
        /// <param name="position">Tab position in twips</param>
        public ITab CreateTab(int position)
        {
            return new Tab(position);
        }

        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        public ITab CreateTab(int position, ETabKind kind)
        {
            return new Tab(position, kind);
        }

        /// <param name="position">Tab position in twips</param>
        /// <param name="lead">Tab lead</param>
        public ITab CreateTab(int position, ETabLead lead)
        {
            return new Tab(position, lead);
        }

        
        /// <param name="position">Tab position in twips</param>
        /// <param name="kind">Tab kind</param>
        /// <param name="lead">Tab lead</param>
        public ITab CreateTab(int position, ETabKind kind, ETabLead lead)
        {
            return new Tab(position, kind, lead);
        }
        #endregion
    }
}