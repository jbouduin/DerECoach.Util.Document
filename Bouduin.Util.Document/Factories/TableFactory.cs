using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Table;
using Bouduin.Util.Document.Generic.Contents.Table.Cells;
using Bouduin.Util.Document.Generic.Formatting;

namespace Bouduin.Util.Document.Factories
{
    public class TableFactory : ITableFactory
    {
        #region fields --------------------------------------------------------
        private readonly ITwipConverter _twipConverter;
        #endregion

        #region table ---------------------------------------------------------
        public ITable CreateTable(ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance)
        {
            return new Table(_twipConverter, cellAppearanceMode,defaultTableCellAppearance);
        }

        public ITable CreateTable(ITableCellAppearance defaultTableCellAppearance)
        {
            return new Table(_twipConverter, defaultTableCellAppearance);
        }

        public ITable CreateTable(ECellAppearanceMode cellAppearanceMode)
        {
            return new Table(_twipConverter, cellAppearanceMode);
        }

        public ITable CreateTable(ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance,
            int rowCount, int columnCount)
        {
            return new Table(_twipConverter, cellAppearanceMode, defaultTableCellAppearance, rowCount, columnCount);
        }

        public ITable CreateTable(ITableCellAppearance defaultTableCellAppearance, int rowCount, int columnCount)
        {
            return new Table(_twipConverter, defaultTableCellAppearance, rowCount, columnCount);
        }

        public ITable CreateTable(ECellAppearanceMode cellAppearanceMode, int rowCount, int columnCount)
        {
            return new Table(_twipConverter, cellAppearanceMode, rowCount, columnCount);
        }
        #endregion

        #region cellappearance ------------------------------------------------
        public ITableCellAppearance CreateTableCellAppearance()
        {
             return new TableCellAppearance(_twipConverter);
        }

        public ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting) 
        {
            return new TableCellAppearance(_twipConverter, borderSetting);
        }

        public ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting, IParagraphFormatting formatting)
        {
            return new TableCellAppearance(_twipConverter, borderSetting, formatting);
        }

        public ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting, IParagraphFormatting formatting, ETableCellVerticalAlign align)
        {
            return new TableCellAppearance(_twipConverter, borderSetting, formatting, align);
        }

        public ITableCellAppearance CreateTableCellAppearance(EBorderSetting borderSetting,
            IParagraphFormatting formatting, ETableCellVerticalAlign align, ETableCellTextFlow textFlow)

        {
            return new TableCellAppearance(_twipConverter, borderSetting, formatting, align, textFlow);
        }

        #endregion
        #region constructor ---------------------------------------------------

        public TableFactory(ITwipConverter twipConverter)
        {
            _twipConverter = twipConverter;
        }
        #endregion
    }
}