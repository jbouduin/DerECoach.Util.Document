using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Factories
{
    public interface IParagraphFactory
    {
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
    }
}