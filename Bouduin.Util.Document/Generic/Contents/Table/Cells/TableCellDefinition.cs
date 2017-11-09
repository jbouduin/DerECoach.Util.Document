using System;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    // TODO check if we still need all this in the interface, even consider removing it an define the required properties in ITableCell
    public interface ITableCellDefinition
    {
        int Width { get; set; }
        bool FirstHorizontallyMergedCell { get; }
        bool HorizontallyMergedCell { get; }
        bool FirstVerticallyMergedCell { get; }
        bool VerticallyMergedCell { get; }
        int RightBoundary { get; }
    }

    internal interface ITableCellDefinitionInternal
    {
        int WidthInternal { get; }
        bool IsWidthSetInternal { get; } 

        bool FirstHorizontallyMergedCellInternal { get; set; }
        bool HorizontallyMergedCellInternal { get; set; }
        bool FirstVerticallyMergedCellInternal { get; set; }
        bool VerticallyMergedCellInternal { get; set; }

    }

    internal class TableCellDefinition : ITableCellDefinition, ITableCellDefinitionInternal
    {
        #region fields --------------------------------------------------------

        private readonly ITableCellInternal _tableCell;
        private bool _firstHorizontallyMergedCell;
        private bool _horizontallyMergedCell;
        private bool _firstVerticallyMergedCell ;
        private bool _verticallyMergedCell;

        #endregion

        #region ITableCellDefinition properties -------------------------------

        public int Width
        {
            get { return WidthInternal;}
            set
            {
                IsWidthSetInternal = true;
                WidthInternal = value;
            }
        }

        /// <summary>
        /// Gets a Boolean value indicating that the cell is the first cell in a range of table cells to be merged.
        /// </summary>
        [RtfControlWord("clmgf")]
        public bool FirstHorizontallyMergedCell
        {
            get { return _firstHorizontallyMergedCell; }
        }

        /// <summary>
        /// Gets a Boolean value indicating that the contents of the table cell are merged with those of the preceding cell.
        /// </summary>
        [RtfControlWord("clmrg")]
        public bool HorizontallyMergedCell
        {
            get { return _horizontallyMergedCell; }
        }

        /// <summary>
        /// Gets a Boolean value indicating that the cell is the first cell in a range of table cells to be vertically merged.
        /// </summary>
        [RtfControlWord("clvmgf")]
        public bool FirstVerticallyMergedCell
        {
            get { return _firstVerticallyMergedCell; }
        }

        /// <summary>
        /// Gets a Boolean value indicating that the contents of the table cell are vertically merged with those of the preceding cell.
        /// </summary>
        [RtfControlWord("clvmrg")]
        public bool VerticallyMergedCell
        {
            get { return _verticallyMergedCell; }
        }

        /// <summary>
        /// Gets the right boundary of the cell in twips.
        /// </summary>
        [RtfControlWord("cellx")]
        public int RightBoundary
        {
            get
            {
                var boundary = 0;

                throw new NotImplementedException();
                //for (var i = 0; i <= _tableCell.ColumnIndexInternal; i++)
                //    boundary += _tableCell.RowInternal.Cells[i].Definition.Width;

                return boundary;
            }
        }
        #endregion

        #region ITableCellDefinitionInternal properties -----------------------

        public int WidthInternal { get; private set; }

        public bool IsWidthSetInternal { get; private set; }

        public bool FirstHorizontallyMergedCellInternal
        {
            get { return _firstHorizontallyMergedCell; }
            set
            {
                _firstHorizontallyMergedCell = value;
                if (_firstHorizontallyMergedCell)
                {
                    _horizontallyMergedCell = false;
                    _tableCell.CellContent.Clear();
                }
            }
        }

        public bool HorizontallyMergedCellInternal
        {
            get { return _horizontallyMergedCell; }
            set
            {
                _horizontallyMergedCell = value;
                if (_horizontallyMergedCell)
                {
                    _firstHorizontallyMergedCell = false;
                    _tableCell.CellContent.Clear();
                }
            }
        }

        public bool FirstVerticallyMergedCellInternal
        {
            get { return _firstVerticallyMergedCell; }
            set
            {
                _firstVerticallyMergedCell = value;
                if (_firstVerticallyMergedCell)
                {
                    _verticallyMergedCell = false;
                    _tableCell.CellContent.Clear();
                }
            }
        }

        public bool VerticallyMergedCellInternal
        {
            get { return _verticallyMergedCell; }
            set
            {
                _verticallyMergedCell = value;
                if (_verticallyMergedCell)
                {
                    _firstVerticallyMergedCell = false;
                    _tableCell.CellContent.Clear();
                }
            }
        }
        
        #endregion

        #region constructor ---------------------------------------------------

        public TableCellDefinition(ITableCellInternal tableCell)
        {
            _tableCell = tableCell;
            
            WidthInternal = 9797;
        }

        #endregion
    }
}