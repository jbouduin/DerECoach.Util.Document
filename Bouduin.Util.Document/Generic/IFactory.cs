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
        #region document ------------------------------------------------------
        /// <summary>
        /// Create a document 
        /// </summary>
        /// <returns></returns>
        IDocument CreateDocument();

        /// <summary>
        /// create a document with the given codepage
        /// </summary>
        /// <param name="codePage"></param>
        /// <returns></returns>
        IDocument CreateDocument(ECodePage codePage);
        #endregion

        #region formatted paragraph -------------------------------------------
        /// <summary>
        /// Create a formatted paragraph with standard formatting
        /// </summary>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph();
        
        /// <summary>
        /// Create a formatted paragraph with the given alignment
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(ETextAlign align);

        /// <summary>
        /// Create a formatted paragraph with the given fontsize
        /// </summary>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(float fontSize);

        /// <summary>
        /// Create a formatted paragraph with the given alignment and fontsize
        /// </summary>
        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        IFormattedParagraph CreateFormattedParagraph(float fontSize, ETextAlign align);
        #endregion

        #region formatted text ------------------------------------------------
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
        #endregion

        #region image ---------------------------------------------------------
        IDocumentImage CreateDocumentImage(Bitmap bitmap);

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format);

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY);
        #endregion

        #region hyperlink -----------------------------------------------------
        IHyperlink CreateHyperlink(string address, IFormattedText text);
        #endregion

        #region special characters --------------------------------------------
        // TODO add other special characters
        ITabCharacter CreateTabCharacter();
        #endregion

        #region utilities -----------------------------------------------------
        ITwipConverter CreateTwipConverter();
        #endregion

        #region tabs ----------------------------------------------------------
        // TODO use position + EMetricUnit instead of twips as input
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
        #endregion
    }
}