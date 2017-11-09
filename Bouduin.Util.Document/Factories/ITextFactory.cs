using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;

namespace Bouduin.Util.Document.Factories
{
    public interface ITextFactory
    {
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

        // TODO use position + EMetricUnit instead of twips as input for tabs
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

        IHyperlink CreateHyperlink(string address, IFormattedText text);
        ITabCharacter CreateTabCharacter();
    }
}