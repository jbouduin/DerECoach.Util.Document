using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Table.Cells;
using Bouduin.Util.Document.Generic.Contents.Table.Columns;
using Bouduin.Util.Document.Generic.Contents.Table.Rows;
using Bouduin.Util.Document.Generic.Documents;

namespace Bouduin.Util.Document.Generic.Contents.Table
{
    public interface ITable: IDocumentContent
    {
        /// <summary>
        /// Gets or sets the CellAppearanceMode. Default is ColumnOverRow
        /// </summary>
        ECellAppearanceMode CellAppearanceMode { get; set; }

        /// <summary>
        /// The Default cell appearance of the table
        /// </summary>
        ITableCellAppearance DefaulTableCellAppearance { get; set; }

        /// <summary>
        /// Add a new cell appearance to the dictionary of appearances
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cellAppearance"></param>
        void AddCellAppearance(string key, ITableCellAppearance cellAppearance);

        /// <summary>
        /// The table rows
        /// </summary>
        IReadOnlyCollection<ITableRow> Rows { get; }

        /// <summary>
        /// The table columns
        /// </summary>
        IReadOnlyCollection<ITableColumn> Columns { get; }

        /// <summary>
        /// The number of rows
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// the number of columns
        /// </summary>
        int ColumnCount{ get; }
        
        /// <summary>
        /// Gets or sets the width of the table in twips.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Gets or sets a cell
        /// </summary>
        /// <param name="columnIndex">the zero based column index</param>
        /// <param name="rowIndex">the zero based row index</param>
        /// <returns></returns>
        ITableCell this[int columnIndex, int rowIndex] { get; set; }

        /// <summary>
        /// Create a row with the correct number of cells
        /// </summary>
        /// <returns></returns>
        ITableRow CreateRow();

        /// <summary>
        /// create a row with the correct number of cells assigning it the given default appearance
        /// </summary>
        /// <param name="defaultAppearance"></param>
        ITableRow CreateRow(ITableCellAppearance defaultAppearance);

        /// <summary>
        /// create a row with the correct number of cells assigning it the appearance with the given key
        /// </summary>
        /// <param name="defaultAppearanceKey"></param>
        ITableRow CreateRow(string defaultAppearanceKey);

        /// <summary>
        /// append a new row to the end of the table.
        /// </summary>
        /// <param name="tableRow"></param>
        void AppendRow(ITableRow tableRow);

        /// <summary>
        /// append a new row at the given index.
        /// </summary>
        /// <param name="rowIndex">The zero based row index</param>
        /// <param name="tableRow"></param>
        void InsertRow(int rowIndex, ITableRow tableRow);
        
        /// <summary>
        /// Create a column
        /// </summary>
        ITableColumn CreateColumn();

        /// <summary>
        /// create a column assigning it the given default appearance
        /// </summary>
        /// <param name="defaultAppearance"></param>
        ITableColumn CreateColumn(ITableCellAppearance defaultAppearance);

        /// <summary>
        /// create a column assigning it the appearance with the given key
        /// </summary>
        /// <param name="defaultAppearanceKey"></param>
        ITableColumn CreateColumn(string defaultAppearanceKey);

        /// <summary>
        /// append a new column to the right of the table
        /// </summary>
        /// <param name="tableColumn"></param>
        /// <returns></returns>
        void AppendColumn(ITableColumn tableColumn);

        /// <summary>
        /// insert a column at the given index.
        /// </summary>
        /// <param name="columnIndex">The zero based column index</param>
        /// <param name="tableColumn"></param>
        /// <returns></returns>
        void InsertColumn(int columnIndex, ITableColumn tableColumn);
    }

    internal interface ITableInternal : ITable, IDocumentContentInternal
    {
        ETableAlign AlignInternal { get; set; }
        Dictionary<string, ITableCellAppearance> Appearances { get; }
        ObservableCollection<ITableRowInternal> RowsInternal { get; }
        ObservableCollection<ITableColumnInternal> ColumnsInternal { get; }
    }

    internal class Table : ADocumentContent, ITableInternal
    {
        #region fields --------------------------------------------------------
        
        private readonly ITwipConverter _twipConverter;
        private readonly Dictionary<string, ITableCellAppearance> _appearances = new Dictionary<string, ITableCellAppearance>();
        private readonly ObservableCollection<ITableRowInternal> _rows;
        private readonly ObservableCollection<ITableColumnInternal> _columns;
        private int _width;

        #endregion

        #region ITable members ------------------------------------------------
        public ECellAppearanceMode CellAppearanceMode { get; set; }
        public ITableCellAppearance DefaulTableCellAppearance { get; set; }

        public void AddCellAppearance(string key, ITableCellAppearance cellAppearance)
        {
            _appearances.Add(key, cellAppearance);
            ((ITableCellAppearanceInternal) cellAppearance).AppearanceKey = key;
        }

        public IReadOnlyCollection<ITableRow> Rows
        {
            get { return new ReadOnlyCollection<ITableRow>(_rows.OfType<ITableRow>().ToList()); }
        }

        public IReadOnlyCollection<ITableColumn> Columns
        {
            get { return new ReadOnlyCollection<ITableColumn>(_columns.OfType<ITableColumn>().ToList()); }
        }

        public int RowCount
        {
            get { return _rows.Count; }
        }

        public int ColumnCount
        {
            get { return _columns.Count; }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                foreach (var row in _rows)
                {
                    row.Width = value;
                }
            }
        }

        public ITableCell this[int rowIndex, int columnIndex]
        {
            get
            {
                // TODO add the rows dynamically
                if (RowCount < rowIndex)
                    throw new ArgumentOutOfRangeException();
                // TODO add the columns dynamically
                if (ColumnCount < columnIndex)
                    throw new ArgumentOutOfRangeException();
                return _rows[rowIndex].Cells[columnIndex];
            }
            set
            {
                _rows[rowIndex].SetCell(columnIndex, value as ITableCellInternal);
            }
        }

        public ITableRow CreateRow()
        {
            return new TableRow(_twipConverter, ColumnCount);
        }

        public ITableRow CreateRow(ITableCellAppearance defaultAppearance)
        {
            return new TableRow(_twipConverter, defaultAppearance, ColumnCount);
        }

        public ITableRow CreateRow(string defaultAppearanceKey)
        {
            return new TableRow(_twipConverter, defaultAppearanceKey, ColumnCount);
        }

        public void AppendRow(ITableRow tableRow)
        {
            throw new NotImplementedException();
        }

        public void InsertRow(int rowIndex, ITableRow tableRow)
        {
            throw new NotImplementedException();
        }

        public ITableColumn CreateColumn()
        {
            return new TableColumn();
        }

        public ITableColumn CreateColumn(ITableCellAppearance defaultAppearance)
        {
            return new TableColumn(defaultAppearance);
        }

        public ITableColumn CreateColumn(string defaultAppearanceKey)
        {
            return new TableColumn(defaultAppearanceKey);
        }

        public void AppendColumn(ITableColumn tableColumn)
        {
            throw new NotImplementedException();
        }

        public void InsertColumn(int columnIndex, ITableColumn tableColumn)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ITableInternal Members ----------------------------------------
        public ETableAlign AlignInternal { get; set; }

        public Dictionary<string, ITableCellAppearance> Appearances
        {
            get { return _appearances; }
        }

        public ObservableCollection<ITableRowInternal> RowsInternal
        {
            get { return _rows; }
        }

        public ObservableCollection<ITableColumnInternal> ColumnsInternal
        {
            get { return _columns; }
        }
        #endregion
        
        #region ADocumentContent overrides ------------------------------------

        public override IDocument DocumentInternal
        {
            set
            {
                SetDocumentInternal(value);
                foreach (var row in _rows)
                {
                    row.TableInternal = this;
                    row.DocumentInternal = Document;
                }
            }
        }

        #endregion

        #region constructor ---------------------------------------------------

        private Table(ITwipConverter twipConverter, int columnCount = 0, int rowCount = 0)
        {
            _twipConverter = twipConverter;
            _rows = new ObservableCollection<ITableRowInternal>();
            _rows.CollectionChanged += RowsCollectionChanged;
            _columns = new ObservableCollection<ITableColumnInternal>();
            _columns.CollectionChanged += ColumnsCollectionChanged;

            for (var col = 1; col <= columnCount; col++)
            {
                _columns.Add(new TableColumn());
            }

            for (var row = 1; row <= rowCount; row++)
            {
                _rows.Add(new TableRow(_twipConverter, columnCount));
            }
        }

        public Table(ITwipConverter twipConverter, ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance)
            : this(twipConverter)
        {
            CellAppearanceMode = cellAppearanceMode;
            DefaulTableCellAppearance = defaultTableCellAppearance;
        }

        public Table(ITwipConverter twipConverter, ITableCellAppearance defaultTableCellAppearance)
            : this(twipConverter)
        {
            DefaulTableCellAppearance = defaultTableCellAppearance;
        }

        public Table(ITwipConverter twipConverter, ECellAppearanceMode cellAppearanceMode)
            : this(twipConverter)
        {
            CellAppearanceMode = cellAppearanceMode;
            DefaulTableCellAppearance = new TableCellAppearance(twipConverter);
        }

        public Table(ITwipConverter twipConverter, ECellAppearanceMode cellAppearanceMode, ITableCellAppearance defaultTableCellAppearance, int rowCount, int columnCount)
            : this(twipConverter, rowCount, columnCount)
        {
            CellAppearanceMode = cellAppearanceMode;
            DefaulTableCellAppearance = defaultTableCellAppearance;
        }

        public Table(ITwipConverter twipConverter, ITableCellAppearance defaultTableCellAppearance, int rowCount, int columnCount)
            : this(twipConverter, rowCount, columnCount)
        {
            DefaulTableCellAppearance = defaultTableCellAppearance;
        }

        public Table(ITwipConverter twipConverter, ECellAppearanceMode cellAppearanceMode, int rowCount, int columnCount)
            : this(twipConverter, rowCount, columnCount)
        {
            CellAppearanceMode = cellAppearanceMode;
            DefaulTableCellAppearance = new TableCellAppearance(twipConverter);
        }
        #endregion

        #region collectionchanged events --------------------------------------
        void ColumnsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                
                foreach (var newItem in e.NewItems.OfType<ITableColumnInternal>())
                {
                    newItem.DocumentInternal = Document;
                    newItem.TableInternal = this;
                }
            }
        }

        void RowsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {

                foreach (var newItem in e.NewItems.OfType<ITableRowInternal>())
                {
                    newItem.DocumentInternal = Document;
                    newItem.TableInternal = this;
                    // TODO 
                    //newItem.Width = _table.Width;
                    //newItem.AlignInternal = Align;

                    //foreach (var cell in rtfTableRow.Cells)
                    //{
                    //    if (_table.ColumnCount > cell.ColumnIndexInternal)
                    //        cell.ColumnInternal = _table.Columns[cell.ColumnIndexInternal];

                    //    if (!cell.Definition.HasStyle)
                    //    {
                    //        if (cell.ColumnInternal != null && cell.ColumnInternal.DefaultCellStyle != null)
                    //            _table.Columns[cell.ColumnIndexInternal].DefaultCellStyle.CopyTo(cell.Definition.StyleInternal);
                    //        else if (_table.DefaultCellStyle != null)
                    //            _table.DefaultCellStyle.CopyTo(cell.Definition.StyleInternal);
                    //    }

                    //    if (!cell.Definition.IsWidthSet)
                    //    {
                    //        if (cell.ColumnInternal != null && cell.ColumnInternal.IsWidthSet)
                    //            cell.Definition.Width = cell.ColumnInternal.Width;
                    //    }
                    //}
                }
            }
        }
        #endregion
    }
}