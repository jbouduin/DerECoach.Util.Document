using System;
using System.Collections;
using System.Collections.Generic;
using Bouduin.Util.Document.Rtf.Contents.Text;

namespace Bouduin.Util.Document.Rtf.Contents.Table.Collections
{
    /// <summary>
    /// Represents a collection of cells in a ESCommon.Rtf.RtfTableRow
    /// </summary>
    public class RtfTableCellCollection : ICollection<RtfTableCell>
    {
        private readonly RtfTableRow _row;
        private readonly List<RtfTableCell> _list;

        /// <summary>
        /// Gets or sets ESCommon.Rtf.RtfTableCell at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfTableCell to get or set.</param>
        public RtfTableCell this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Gets the number of cells in the collection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCellCollection class.
        /// </summary>
        /// <param name="row">Owning row.</param>
        internal RtfTableCellCollection(RtfTableRow row)
        {
            _list = new List<RtfTableCell>();
            _row = row;
        }


        /// <summary>
        /// Adds a new ESCommon.Rtf.RtfTableCell to the collection.
        /// </summary>
        public void Add()
        {
            Add(new RtfTableCell());
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableCell to the collection.
        /// </summary>
        public void Add(RtfTableCell rtfTableCell)
        {
            OnAddingCell(rtfTableCell);

            var num = _list.Count;

            _list.Add(rtfTableCell);
            _row.Definitions.AddInternal(rtfTableCell.Definition);

            rtfTableCell.ColumnIndexInternal = num;
            rtfTableCell.RowIndexInternal = _row.Index;

            var table = _row.Table;

            if (table != null && table.ColumnCount > num)
                rtfTableCell.ColumnInternal = table.Columns[num];

            if (!rtfTableCell.Definition.IsWidthSet)
            {
                if (table != null && table.ColumnCount > 0 && table.Columns[num].IsWidthSet)
                    rtfTableCell.Definition.Width = table.Columns[num].Width;
            }

            if (!rtfTableCell.Definition.HasStyle)
            {
                if (table != null && table.ColumnCount > 0 && table.Columns[num].DefaultCellStyle != null)
                    table.Columns[num].DefaultCellStyle.CopyTo(rtfTableCell.Definition.StyleInternal);
                else if (table != null && table.DefaultCellStyle != null)
                    table.DefaultCellStyle.CopyTo(rtfTableCell.Definition.StyleInternal);
                else
                    rtfTableCell.Definition.StyleInternal = new RtfTableCellStyle();
            }

            _row.ResizeCellsInternal();
        }

        /// <summary>
        /// Adds a new ESCommon.Rtf.RtfTableCell with specified text to the collection.
        /// </summary>
        public void Add(string text)
        {
            Add(new RtfTableCell(text));
        }

        /// <summary>
        /// Adds a new ESCommon.Rtf.RtfTableCell with specified text to the collection.
        /// </summary>
        public void Add(RtfParagraphContentBase text)
        {
            Add(new RtfTableCell(text));
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableCell objects to the collection.
        /// </summary>
        public void AddRange(RtfTableCell[] rtfTableCells)
        {
            foreach (var cell in rtfTableCells)
            {
                if (cell != null)
                    Add(cell);
                else
                    Add(new RtfTableCell());
            }
        }

        /// <summary>
        /// Determines if an element is in the collection.
        /// </summary>
        /// <param name="rtfTableCell"></param>
        public bool Contains(RtfTableCell rtfTableCell)
        {
            return _list.Contains(rtfTableCell);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(RtfTableCell[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        

        private void OnAddingCell(RtfTableCell rtfTableCell)
        {
            if (rtfTableCell == null)
                throw (new ArgumentNullException("RtfTableCell cannot be null"));

            if (rtfTableCell.RowInternal != null)
                throw (new InvalidOperationException("RtfTableCell already belongs to a RtfTableRow"));

            rtfTableCell.RowInternal = _row;
            rtfTableCell.DocumentInternal = _row.DocumentInternal;
        }
        

        void ICollection<RtfTableCell>.Clear()
        {

        }

        bool ICollection<RtfTableCell>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<RtfTableCell>.Remove(RtfTableCell item)
        {
            return false;
        }

        IEnumerator<RtfTableCell> IEnumerable<RtfTableCell>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}