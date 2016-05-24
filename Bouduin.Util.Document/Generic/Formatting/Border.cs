using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Formatting
{
    /// <summary>
    /// Represents a border.
    /// </summary>
    internal class Border : IBorder
    {
        #region fields --------------------------------------------------------
        private readonly ITwipConverter _twipConverter;
        private int _width = 10;
        private EBorderStyle _style = EBorderStyle.SingleThicknessBorder;
        private int _colorIndex = -1;
        #endregion

        #region IBorder properties --------------------------------------------
        /// <summary>
        /// Border width in twips.
        /// </summary>
        [RtfControlWord("brdrw")]
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Border style.
        /// </summary>
        [RtfControlWord]
        public EBorderStyle Style
        {
            get { return _style; }
            set { _style = value; }
        }

        /// <summary>
        /// Index of entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfControlWord("brdrcf"), RtfIndex]
        public int ColorIndex
        {
            get { return _colorIndex; }
            set { _colorIndex = value; }
        }
        #endregion

        #region IBorder methods -----------------------------------------------
        /// <summary>
        /// Sets the properties of the current border.
        /// </summary>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border style.</param>
        /// <param name="colorIndex">Index of entry in the color table.</param>
        public void SetProperties(float width, EBorderStyle style, int colorIndex)
        {
            Width = _twipConverter.ToTwip(width, EMetricUnit.Point);
            Style = style;
            ColorIndex = colorIndex;
        }

        /// <summary>
        /// Copy all the properties of the current border to specified IBorder object.
        /// </summary>
        /// <param name="border">Border object to copy to.</param>
        public void CopyTo(IBorder border)
        {
            border.Width = Width;
            border.Style = Style;
            border.ColorIndex = ColorIndex;
        }
        #endregion

        #region constructor ---------------------------------------------------

        public Border(ITwipConverter twipConverter)
        {
            _twipConverter = twipConverter;
        }
        #endregion
    }
}