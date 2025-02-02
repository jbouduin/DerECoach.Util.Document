﻿using Bouduin.Util.Document.Rtf.Attributes;
using Bouduin.Util.Document.Rtf.Contents.Table.Collections;
using Bouduin.Util.Document.Rtf.Document;

namespace Bouduin.Util.Document.Rtf.Contents.Table
{
    /// <summary>
    /// Defines table align
    /// </summary>
    [RtfEnumAsControlWord(RtfEnumConversion.UseAttribute)]
    public enum RtfTableAlign
    {
        [RtfControlWord("trql")]
        Left,
        [RtfControlWord("trqc")]
        Center,
        [RtfControlWord("trqr")]
        Right
    }

    /// <summary>
    /// Represents a table.
    /// </summary>
    public class RtfTable : ARtfDocumentContent
    {
        private RtfTableColumnCollection _columns;
        private RtfTableRowCollection _rows;
        private int _width = 9797;
        private RtfTableAlign _align = RtfTableAlign.Center;
        private RtfTableCellStyle _defaultCellStyle;

        internal override RtfDocument DocumentInternal
        {
            get
            {
                return base.DocumentInternal;
            }
            set
            {
                base.DocumentInternal = value;

                foreach (var row in _rows)
                {
                    row.DocumentInternal = value;
                }
            }
        }

        /// <summary>
        /// Gets a collection that contains all the columns of the table.
        /// </summary>
        [RtfIgnore]
        public RtfTableColumnCollection Columns
        {
            get { return _columns; }
        }

        /// <summary>
        /// Gets a collection that contains all the rows of the table.
        /// </summary>
        [RtfInclude]
        public RtfTableRowCollection Rows
        {
            get { return _rows; }
        }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        public int ColumnCount
        {
            get { return Columns.Count; }
        }

        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        public int RowCount
        {
            get { return Rows.Count; }
        }

        /// <summary>
        /// Gets or sets the width of the table in twips.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set 
            {
                _width = value;

                foreach (var row in _rows)
                    row.Width = value;
            }
        }

        /// <summary>
        /// Gets or sets table align.
        /// </summary>
        public RtfTableAlign Align
        {
            get { return _align; }
            set
            {
                _align = value;

                if (_rows != null)
                    foreach (var row in _rows)
                        row.AlignInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the default cell style to be applied to the cells in the ESCommon.Rtf.RtfTable if no other cell style properties are set.
        /// </summary>
        public RtfTableCellStyle DefaultCellStyle
        {
            get { return _defaultCellStyle; }
            set
            {
                _defaultCellStyle = value;

                foreach (var row in _rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        if (!cell.Definition.HasStyle)
                        {
                            cell.Definition.StyleInternal = _defaultCellStyle;
                            if (cell.IsFormattingIncluded = _defaultCellStyle != null)
                                cell.Formatting = _defaultCellStyle.DefaultParagraphFormatting;
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTable.
        /// </summary>
        public RtfTable()
        {
            Initialize();
        }
        
        /// <param name="columnCount">Number of columns</param>
        /// <param name="rowCount">Number of rows</param>
        public RtfTable(int columnCount, int rowCount)
        {
            Initialize(columnCount, rowCount);
        }

        /// <param name="align">Table align</param>
        public RtfTable(RtfTableAlign align)
        {
            Align = align;
            Initialize();
        }
        
        /// <param name="align">Table align</param>
        /// <param name="columnCount">Number of columns</param>
        /// <param name="rowCount">Number of rows</param>
        public RtfTable(RtfTableAlign align, int columnCount, int rowCount)
        {
            Align = align;
            Initialize(columnCount, rowCount);
        }


        private void Initialize()
        {
            _columns = new RtfTableColumnCollection(this);
            _rows = new RtfTableRowCollection(this);
        }

        private void Initialize(int columnCount, int rowCount)
        {
            Initialize();

            _columns.AddRange(new RtfTableColumn[columnCount]);
            _rows.AddRange(new RtfTableRow[rowCount]);
        }

        /// <summary>
        /// Provides an indexer to get or set the cell located at the intersection of the column and row with the specified indexes.
        /// </summary>
        /// <param name="columnIndex">The index of the column containing the cell.</param>
        /// <param name="rowIndex">The index of the row containing the cell.</param>
        [RtfIgnore]
        public RtfTableCell this[int columnIndex, int rowIndex]
        {
            get { return Rows[rowIndex].Cells[columnIndex]; }
            set { Rows[rowIndex].Cells[columnIndex] = value; }
        }

        /// <summary>
        /// Merge the cell located at the intersection of the column and row with the specified indexes vertically with the specified number of cells.
        /// </summary>
        /// <param name="columnIndex">The index of the column containing the cell.</param>
        /// <param name="rowIndex">The index of the row containing the cell.</param>
        /// <param name="count">The number of cells to merge.</param>
        public void MergeCellsVertically(int columnIndex, int rowIndex, int count)
        {
            var firstDef = this[columnIndex, rowIndex].Definition;
            firstDef.FirstVerticallyMergedCellInternal = true;

            for (var i = 1; i < count && i + rowIndex < Rows.Count; i++)
            {
                var cellDef = this[columnIndex, i + rowIndex].Definition;
                cellDef.VerticallyMergedCellInternal = true;

                firstDef.Style.CopyTo(cellDef.StyleInternal);

                cellDef.WidthInternal = firstDef.Width;
            }
        }

        /// <summary>
        /// Merge the cell located at the intersection of the column and row with the specified indexes horizontally with the specified number of cells.
        /// </summary>
        /// <param name="columnIndex">The index of the column containing the cell.</param>
        /// <param name="rowIndex">The index of the row containing the cell.</param>
        /// <param name="count">The number of cells to merge.</param>
        public void MergeCellsHorizontally(int columnIndex, int rowIndex, int count)
        {
            var firstDef = this[columnIndex, rowIndex].Definition;
            firstDef.FirstHorizontallyMergedCellInternal = true;

            for (var i = 1; i < count && i + columnIndex < Rows[rowIndex].Cells.Count; i++)
            {
                var cellDef = this[i + columnIndex, rowIndex].Definition;
                cellDef.HorizontallyMergedCellInternal = true;

                firstDef.Style.CopyTo(cellDef.StyleInternal);
            }
        }
    }
}