using System;
using Bouduin.Util.Document.Generic.Contents.Table.Cells;
using Bouduin.Util.Document.Generic.Documents;

namespace Bouduin.Util.Document.Generic.Contents.Table.Columns
{
    public interface ITableColumn: IDocumentContent
    {
        ITableCellAppearance DefaulTableColumnAppearance { get; set; }
    }

    internal interface ITableColumnInternal : ITableColumn, IDocumentContentInternal
    {
        ITableInternal TableInternal { get; set; }
        string DefaultTableColumnAppearanceKey { get; }
    }

    internal class TableColumn : ADocumentContent, ITableColumnInternal
    {
        #region ITableColumn members ------------------------------------------
        public ITableCellAppearance DefaulTableColumnAppearance
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DefaultTableColumnAppearanceKey))
                    return null;

                return TableInternal.Appearances[DefaultTableColumnAppearanceKey];
            }
            set
            {
                if (string.IsNullOrWhiteSpace(((ITableCellAppearanceInternal)value).AppearanceKey))
                {

                    ((ITableCellAppearanceInternal)value).AppearanceKey = Guid.NewGuid().ToString();
                    TableInternal.Appearances.Add(((ITableCellAppearanceInternal)value).AppearanceKey, value);
                }
                DefaultTableColumnAppearanceKey = ((ITableCellAppearanceInternal)value).AppearanceKey;

            }
        }
        #endregion

        #region ITableColumnInternal members ----------------------------------
        public ITableInternal TableInternal { get; set; }
        public string DefaultTableColumnAppearanceKey { get; private set; }
        #endregion

        #region Constructor ---------------------------------------------------
        public TableColumn()
        {
            
        }

        public TableColumn(ITableCellAppearance tableCellAppearance)
        {
            DefaulTableColumnAppearance = tableCellAppearance;
        }

        public TableColumn(string tableCellAppearanceKey)
        {
            DefaultTableColumnAppearanceKey = tableCellAppearanceKey;
        }
        #endregion
    }
}