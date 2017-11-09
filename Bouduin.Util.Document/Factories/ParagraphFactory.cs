using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Factories
{
    public class ParagraphFactory : IParagraphFactory
    {
        #region fields --------------------------------------------------------
        private readonly ITwipConverter _twipConverter;
        #endregion

        #region IParagraphFactory members -------------------------------------
        public IFormattedParagraph CreateFormattedParagraph()
        {
            return new FormattedParagraph(_twipConverter);
        }

        /// <param name="align"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(ETextAlign align)
        {
            return new FormattedParagraph(_twipConverter, align);
        }

        /// <param name="fontSize"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(float fontSize)
        {
            return new FormattedParagraph(_twipConverter, fontSize);
        }

        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public IFormattedParagraph CreateFormattedParagraph(float fontSize, ETextAlign align)
        {
            return new FormattedParagraph(_twipConverter, fontSize, align);
        }
        #endregion

        #region constructor ---------------------------------------------------

        public ParagraphFactory(ITwipConverter twipConverter)
        {
            _twipConverter = twipConverter;
        }
        #endregion
    }
}