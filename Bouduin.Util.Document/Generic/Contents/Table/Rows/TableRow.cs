using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Table.Cells;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Rows
{
    public interface ITableRow: IDocumentContent
    {
        int Width { get; set; }
        ETableAlign Align { get; set; }
        ITableRowPadding TableRowPadding { get; }
        ReadOnlyCollection<ITableCell> Cells { get; }
        ITableCellAppearance DefaulTableRowAppearance { get; set; }
    }

    internal interface ITableRowInternal : ITableRow, IDocumentContentInternal
    {
        
        ITableInternal TableInternal { get; set; }
        ETableAlign AlignInternal { get; set; }
        ObservableCollection<ITableCellInternal> CellsInternal { get; }
        void SetCell(int columnIndex, ITableCellInternal tableCellInternal);
        string DefaultTableRowAppearanceKey { get; }
    }

    /// <summary>
    /// Represents a table row.
    /// </summary>
    [RtfControlWord("trowd"), RtfControlWordDenotingEnd("row")]
    internal class TableRow : ADocumentContent, ITableRowInternal
    {
        #region fields --------------------------------------------------------

        private int _width = 9797;
        private readonly ObservableCollection<ITableCellInternal> _cells;
        private ITableInternal _tableInternal;
        #endregion

        #region ITableRow members ---------------------------------------------

        /// <summary>
        /// Gets or sets the width of the row in twips.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                ResizeCellsInternal();
            }
        }

        public ITableRowPadding TableRowPadding { get; private set; }

        /// <summary>
        /// Gets or sets the height of the row in twips. Default is 0 (auto).
        /// </summary>
        [RtfControlWord("trrh")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the align of the table row.
        /// </summary>
        [RtfControlWord]
        public ETableAlign Align
        {
            get { return AlignInternal; }
            set
            {
                if (TableInternal != null)
                    return;

                AlignInternal = value;
            }
        }

        public ReadOnlyCollection<ITableCell> Cells
        {
            get { return new ReadOnlyCollection<ITableCell>(_cells.OfType<ITableCell>().ToList()); }
        }


        public ITableCellAppearance DefaulTableRowAppearance
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DefaultTableRowAppearanceKey))
                    return null;

                return TableInternal.Appearances[DefaultTableRowAppearanceKey];
            }
            set
            {
                if (string.IsNullOrWhiteSpace(((ITableCellAppearanceInternal) value).AppearanceKey))
                {
                    
                    ((ITableCellAppearanceInternal)value).AppearanceKey = Guid.NewGuid().ToString(); 
                    TableInternal.Appearances.Add(((ITableCellAppearanceInternal)value).AppearanceKey, value);
                }
                DefaultTableRowAppearanceKey = ((ITableCellAppearanceInternal)value).AppearanceKey;
                
            } 
        }
        #endregion

        #region ITableRowInternal members -------------------------------------

        public ITableInternal TableInternal
        {
            get { return _tableInternal; }
            set
            {
                _tableInternal = value;
                foreach (var cell in _cells)
                {
                    cell.TableInternal = TableInternal;
                }
            }
        }

        public ETableAlign AlignInternal { get; set; }

        public ObservableCollection<ITableCellInternal> CellsInternal
        {
            get { return _cells; }
        }

        public void SetCell(int columnIndex, ITableCellInternal tableCellInternal)
        {
            if (TableInternal.ColumnCount < columnIndex)
                throw new ArgumentOutOfRangeException("columnIndex", "Table has not that many columns");

            _cells[columnIndex] = tableCellInternal;

        }

        public string DefaultTableRowAppearanceKey { get; private set; }
        #endregion

        #region basemember overrides ------------------------------------------

        public override IDocument DocumentInternal
        {
            set
            {
                SetDocumentInternal(value);
                foreach (var cell in _cells)
                {
                    cell.DocumentInternal = value;
                }
                // TODO set the document on all cells
            }
        }

        #endregion

        #region constructor ---------------------------------------------------
        public TableRow(ITwipConverter twipConverter, int columnCount = 0)
        {
            AlignInternal = ETableAlign.Center;
            TableRowPadding = new TableRowPadding();
            
            _cells = new ObservableCollection<ITableCellInternal>();
            _cells.CollectionChanged += CellsCollectionChanged;

            for (var col = 1; col <= columnCount; col++)
            {
                _cells.Add(new TableCell(twipConverter));
            }
        }

        public TableRow(ITwipConverter twipConverter, ITableCellAppearance defaultAppearance, int columnCount = 0):
            this(twipConverter, columnCount)
        {
            DefaulTableRowAppearance = defaultAppearance;
        }

        public TableRow(ITwipConverter twipConverter, string appearanceKey, int columnCount = 0) :
            this(twipConverter, columnCount)
        {
            DefaultTableRowAppearanceKey = appearanceKey;
        }
        #endregion

        #region private helper methods ----------------------------------------
        
        #endregion

        #region collectionevents ----------------------------------------------
        void CellsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {

                foreach (var newItem in e.NewItems.OfType<ITableCellInternal>())
                {
                    newItem.RowInternal = this;
                    newItem.TableInternal = TableInternal;
                }
            }
        }
        #endregion

        internal void ResizeCellsInternal()
        {
            throw new NotImplementedException();
            //int
            //    count = cells.Count,
            //    availableWidth = _width,
            //    fixedWidth = 0;

            //for (var i = 0; i < cells.Count; i++)
            //{
            //    if (cells[i].Definition.IsWidthSet)
            //    {
            //        count--;
            //        availableWidth -= cells[i].Definition.WidthInternal;
            //        fixedWidth += cells[i].Definition.WidthInternal;
            //    }
            //}

            //if (count > 0)
            //{
            //    var cellWidth = availableWidth / count;

            //    if (cellWidth < 225)
            //        throw (new InvalidOperationException("Too many cells in a row"));

            //    for (var i = 0; i < cells.Count; i++)
            //    {
            //        if (!cells[i].Definition.IsWidthSet)
            //            cells[i].Definition.WidthInternal = availableWidth / count;
            //    }
            //}

            //if (fixedWidth > 9797)
            //    throw (new InvalidOperationException("Width is too large"));
        }
    }
}