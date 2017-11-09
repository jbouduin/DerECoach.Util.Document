using System;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    
    /// <summary>
    /// Represents table cell appearance.
    /// </summary>
    public class TableCellAppearance : ITableCellAppearanceInternal
    {
        #region fields ----------------------------------------------
        private ETableCellVerticalAlign _verticalAlign = ETableCellVerticalAlign.Center;
        private readonly TableCellBorders _borders;
        private ETableCellTextFlow _textFlow = ETableCellTextFlow.LeftToRightTopToBottom;
        private IParagraphFormatting _defaultParagraphFormatting;
        private string _appearanceKey;
        #endregion

        #region ITableCellAppearance Properties ------------------------------------
        /// <summary>
        /// Gets or sets vertical align of the text inside the cell.
        /// </summary>
        [RtfControlWord]
        public ETableCellVerticalAlign VerticalAlign
        {
            get { return _verticalAlign; }
            set { _verticalAlign = value; }
        }

        /// <summary>
        /// Gets borders of the cell.
        /// </summary>
        [RtfInclude]
        public ITableCellBorders Borders
        {
            get { return _borders; }
        }

        /// <summary>
        /// Gets or sets the direction of text flow inside the cell
        /// </summary>
        [RtfControlWord]
        public ETableCellTextFlow TextFlow
        {
            get { return _textFlow; }
            set { _textFlow = value; }
        }

        /// <summary>
        /// Gets or sets the formatting applied to paragraphs inside the cell by default.
        /// </summary>
        public IParagraphFormatting DefaultParagraphFormatting
        {
            get { return _defaultParagraphFormatting; }
            set { _defaultParagraphFormatting = value; }
        }
        #endregion

        #region ITableCellAppearance methods ---------------------------------------
        /// <summary>
        /// Copies all properties of the current cell appearance to the specified TableCellAppearance object.
        /// </summary>
        /// <param name="cellAppearance">Cell appearance object to copy to.</param>
        public void CopyTo(ITableCellAppearance cellAppearance)
        {
            
            ((TableCellAppearance)cellAppearance)._verticalAlign = _verticalAlign;

            _borders.Top.CopyTo(((TableCellAppearance)cellAppearance)._borders.Top);
            _borders.Left.CopyTo(((TableCellAppearance)cellAppearance)._borders.Left);
            _borders.Bottom.CopyTo(((TableCellAppearance)cellAppearance)._borders.Bottom);
            _borders.Right.CopyTo(((TableCellAppearance)cellAppearance)._borders.Right);

            ((TableCellAppearance)cellAppearance)._textFlow = _textFlow;
        }

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        public void SetBorders(EBorderSetting borderSetting)
        {
            SetBorders(borderSetting, .5F, EBorderStyle.SingleThicknessBorder, -1);
        }

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        public void SetBorders(EBorderSetting borderSetting, float width)
        {
            SetBorders(borderSetting, width, EBorderStyle.SingleThicknessBorder, -1);
        }

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border appearance.</param>
        public void SetBorders(EBorderSetting borderSetting, float width, EBorderStyle style)
        {
            SetBorders(borderSetting, width, style, -1);
        }

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border appearance.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        public void SetBorders(EBorderSetting borderSetting, float width, EBorderStyle style, int colorIndex)
        {
            if ((borderSetting & EBorderSetting.Top) == EBorderSetting.Top)
                Borders.Top.SetProperties(width, style, colorIndex);
            else
                Borders.Top.Width = 0;

            if ((borderSetting & EBorderSetting.Left) == EBorderSetting.Left)
                Borders.Left.SetProperties(width, style, colorIndex);
            else
                Borders.Left.Width = 0;

            if ((borderSetting & EBorderSetting.Bottom) == EBorderSetting.Bottom)
                Borders.Bottom.SetProperties(width, style, colorIndex);
            else
                Borders.Bottom.Width = 0;

            if ((borderSetting & EBorderSetting.Right) == EBorderSetting.Right)
                Borders.Right.SetProperties(width, style, colorIndex);
            else
                Borders.Right.Width = 0;
        }
        #endregion

        #region ITableCellAppearanceInternal Properties -----------------------

        public string AppearanceKey
        {
            get { return _appearanceKey; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("AppearanceKey may not be null or empty", "value");
                if (!string.IsNullOrEmpty(_appearanceKey))
                    throw new NotSupportedException("The Appearancekey can not be altered");
                _appearanceKey = value;
            }
        }

        #endregion

        #region constructor ---------------------------------------------------
        public TableCellAppearance(ITwipConverter twipConverter)
        {
             _borders = new TableCellBorders(twipConverter);
        }

        public TableCellAppearance(ITwipConverter twipConverter, EBorderSetting borderSetting) : this(twipConverter)
        {
            SetBorders(borderSetting);
        }

        /// <param name="twipConverter"></param>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        public TableCellAppearance(ITwipConverter twipConverter, EBorderSetting borderSetting, IParagraphFormatting formatting)
            : this(twipConverter)
        {
            SetBorders(borderSetting);

            _defaultParagraphFormatting = formatting;
        }

        /// <param name="twipConverter"></param>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        /// <param name="align">Vertical align of the text inside the cell.</param>
        public TableCellAppearance(ITwipConverter twipConverter, EBorderSetting borderSetting, IParagraphFormatting formatting, ETableCellVerticalAlign align)
            : this(twipConverter)
        {
            SetBorders(borderSetting);

            _defaultParagraphFormatting = formatting;
            _verticalAlign = align;
        }

        /// <param name="twipConverter"></param>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        /// <param name="align">Vertical align of the text inside the cell.</param>
        /// <param name="textFlow">Direction of text flow inside the cell.</param>
        public TableCellAppearance(ITwipConverter twipConverter, EBorderSetting borderSetting, IParagraphFormatting formatting, ETableCellVerticalAlign align, ETableCellTextFlow textFlow)
            : this(twipConverter)
        {
            SetBorders(borderSetting);

            _defaultParagraphFormatting = formatting;
            _verticalAlign = align;
            _textFlow = textFlow;           
        }
        #endregion

        
    }
}