using Bouduin.Util.Document.Generic.Contents.Table;
using Bouduin.Util.Document.Generic.Contents.Table.Cells;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Factories
{
    public interface ITableFactory
    {
        ITable CreateTable(ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance);
        ITable CreateTable(ITableCellAppearance defaultTableCellAppearance);
        ITable CreateTable(ECellAppearanceMode cellAppearanceMode);
        ITable CreateTable(ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance,
            int rowCount, int columnCount);
        ITable CreateTable(ITableCellAppearance defaultTableCellAppearance, int rowCount, int columnCount);
        ITable CreateTable(ECellAppearanceMode cellAppearanceMode, int rowCount, int columnCount);

        ITableCellAppearance CreateTableCellAppearance();
        ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting);

        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting, IParagraphFormatting formatting);

        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        /// <param name="align">Vertical align of the text inside the cell.</param>
        ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting, IParagraphFormatting formatting, ETableCellVerticalAlign align);

        /// <param name="borderSetting">Cell border setting.</param>
        /// <param name="formatting">Formatting applied to paragraphs inside the cell by default.</param>
        /// <param name="align">Vertical align of the text inside the cell.</param>
        /// <param name="textFlow">Direction of text flow inside the cell.</param>
        ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting,
            IParagraphFormatting formatting, ETableCellVerticalAlign align, ETableCellTextFlow textFlow);
    }
}