using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Contents.Text.Hyperlinks;

namespace Bouduin.Util.Document.Factories
{
    // TODO the other special characters
    public class TextFactory : ITextFactory
    {
        #region ITextFactory --------------------------------------------------

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

        public IHyperlink CreateHyperlink(string address, IFormattedText text)
        {
            return new Hyperlink(address, text);
        }

        public ITabCharacter CreateTabCharacter()
        {
            return new TabCharacter();
        }
        #endregion 
    }
}