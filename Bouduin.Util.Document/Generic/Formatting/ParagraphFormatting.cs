using System;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Represents paragraph formatting.
    /// </summary>
    internal class ParagraphFormatting : IParagraphFormatting
    {
        #region fields --------------------------------------------------------
        private ETextAlign _align = ETextAlign.Left;
        private float _fontSize = 12F;
        private int _backgroundColorIndex = -1;
        private int _textColorIndex = -1;
        private int _fontIndex = -1;
        #endregion 

        #region IParagraphFormatting members ----------------------------------
        /// <summary>
        /// Default is left.
        /// </summary>
        [RtfSortIndex(0), RtfControlWord]
        public ETextAlign Align
        {
            get { return _align; }
            set { _align = value; }
        }

        /// <summary>
        /// Paragraph first line indent in twips. Default is 0.
        /// </summary>
        [RtfSortIndex(1), RtfControlWord("fi")]
        public int FirstLineIndent { get; set; }

        /// <summary>
        /// Paragraph left indent in twips. Default is 0.
        /// </summary>
        [RtfSortIndex(2), RtfControlWord("li")]
        public int IndentLeft { get; set; }

        /// <summary>
        /// Paragraph right indent in twips. Default is 0.
        /// </summary>
        [RtfSortIndex(3), RtfControlWord("ri")]
        public int IndentRight { get; set; }

        /// <summary>
        /// Gets space between lines in twips. The value is used by RtfWriter.
        /// </summary>
        [RtfSortIndex(4), RtfControlWord("sl")]
        public int TwipLineSpacing
        {
            get { return (int)Math.Round(LineSpacingPercent * FontSize * TwipConverter.TwipsInPoint); }
        }

        /// <summary>
        /// Space before paragraph in twips. Default is 0.
        /// </summary>
        [RtfSortIndex(5), RtfControlWord("sb")]
        public int SpaceBefore { get; set; }

        /// <summary>
        /// Space after paragraph in twips. Default is 0.
        /// </summary>
        [RtfSortIndex(6), RtfControlWord("sa")]
        public int SpaceAfter { get; set; }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfSortIndex(7), RtfControlWord("cb"), RtfIndex]
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set { _backgroundColorIndex = value; }
        }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfSortIndex(8), RtfControlWord("cf"), RtfIndex]
        public int TextColorIndex
        {
            get { return _textColorIndex; }
            set { _textColorIndex = value; }
        }

        /// <summary>
        /// Index of an entry in the font table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfSortIndex(9), RtfControlWord("f"), RtfIndex]
        public int FontIndex
        {
            get { return _fontIndex; }
            set { _fontIndex = value; }
        }

        /// <summary>
        /// Gets the font size in half points. Used by RtfWriter.
        /// </summary>
        [RtfSortIndex(10), RtfControlWord("fs")]
        public int HalfPointFontSize
        {
            get { return (int)Math.Round(_fontSize * 2); }
        }

        /// <summary>
        /// Font size in points. Default is 12.
        /// </summary>
        public float FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        /// <summary>
        /// Space between lines in percent
        /// . Default is 0 and the space is automatically determined by the tallest character in the line.
        /// </summary>
        public float LineSpacingPercent { get; set; }
        #endregion

        #region constructor ---------------------------------------------------
        /// <summary>
        /// Initializes a new instance of ParagraphFormatting class.
        /// </summary>
        public ParagraphFormatting()
        {
        }

        /// <summary>
        /// Initializes a new instance of ParagraphFormatting class.
        /// </summary>
        /// <param name="fontSize">Font size in points.</param>
        public ParagraphFormatting(float fontSize)
        {
            FontSize = fontSize;
        }

        /// <summary>
        /// Initializes a new instance of ParagraphFormatting class.
        /// </summary>
        /// <param name="align">Text align inside the paragraph.</param>
        public ParagraphFormatting(ETextAlign align)
        {
            Align = align;
        }

        /// <summary>
        /// Initializes a new instance of ParagraphFormatting class.
        /// </summary>
        /// <param name="fontSize">Font size in points.</param>
        /// <param name="align">Text align inside the paragraph.</param>
        public ParagraphFormatting(float fontSize, ETextAlign align)
        {
            FontSize = fontSize;
            Align = align;
        }
        #endregion
    }
}