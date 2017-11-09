using System;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    public interface ITableCellAppearance
    {
        /// <summary>
        /// Gets or sets vertical align of the text inside the cell.
        /// </summary>
        ETableCellVerticalAlign VerticalAlign { get; set; }

        /// <summary>
        /// Gets borders of the cell.
        /// </summary>
        ITableCellBorders Borders { get; }

        /// <summary>
        /// Gets or sets the direction of text flow inside the cell
        /// </summary>
        ETableCellTextFlow TextFlow { get; set; }

        /// <summary>
        /// Gets or sets the formatting applied to paragraphs inside the cell by default.
        /// </summary>
        IParagraphFormatting DefaultParagraphFormatting { get; set; }

        /// <summary>
        /// Copies all properties of the current cell appearance to the specified TableCellAppearance object.
        /// </summary>
        /// <param name="cellAppearance">Cell appearance object to copy to.</param>
        [Obsolete]
        void CopyTo(ITableCellAppearance cellAppearance);

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        void SetBorders(EBorderSetting borderSetting);

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        void SetBorders(EBorderSetting borderSetting, float width);

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border appearance.</param>
        void SetBorders(EBorderSetting borderSetting, float width, EBorderStyle style);

        /// <summary>
        /// Sets border appearance.
        /// </summary>
        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border appearance.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        void SetBorders(EBorderSetting borderSetting, float width, EBorderStyle style, int colorIndex);
        
    }

    internal interface ITableCellAppearanceInternal: ITableCellAppearance
    {
        string AppearanceKey { get; set; }
    }
}