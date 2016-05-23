using System;
using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Contents.Table.Collections
{
    /// <summary>
    /// Represents a collection of rows in a ESCommon.Rtf.RtfTable
    /// </summary>
    public class RtfTableRowCollection : ICollection<RtfTableRow>
    {
        private readonly RtfTable _table;
        private readonly List<RtfTableRow> _list;

        /// <summary>
        /// Gets ESCommon.Rtf.RtfTableRow at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfTableRow to get.</param>
        public RtfTableRow this[int index]
        {
            get { return _list[index]; }
        }

        /// <summary>
        /// Gets the number of rows in the collection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableRowCollection class.
        /// </summary>
        /// <param name="table">Owning table.</param>
        internal RtfTableRowCollection(RtfTable table)
        {
            _list = new List<RtfTableRow>();
            _table = table;
        }


        /// <summary>
        /// Adds a new ESCommon.Rtf.RtfTableRow to the collection.
        /// </summary>
        public void Add()
        {
            Add(new RtfTableRow(_table.ColumnCount));
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableRow to the collection.
        /// </summary>
        public void Add(RtfTableRow rtfTableRow)
        {
            OnAddingRow(rtfTableRow);

            var num = _list.Count;
            
            _list.Add(rtfTableRow);

            rtfTableRow.IndexInternal = num;

            foreach (var cell in rtfTableRow.Cells)
                cell.RowIndexInternal = num;
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableRow objects to the collection.
        /// </summary>
        public void AddRange(RtfTableRow[] rtfTableRows)
        {
            foreach (var row in rtfTableRows)
            {
                if (row != null)
                    Add(row);
                else
                    Add();
            }
        }

        /// <summary>
        /// Determines if an element is in the collection.
        /// </summary>
        /// <param name="cell">An instance of ESCommon.Rtf.RtfTableRow to locate in the collection.</param>
        public bool Contains(RtfTableRow rtfTableRow)
        {
            return _list.Contains(rtfTableRow);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(RtfTableRow[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }


        private void OnAddingRow(RtfTableRow rtfTableRow)
        {
            if (rtfTableRow == null)
                throw (new ArgumentNullException("RtfTableRow cannot be null"));

            if (rtfTableRow.TableInternal != null)
                throw (new InvalidOperationException("RtfTableRow already belongs to a RtfTable"));

            rtfTableRow.TableInternal = _table;
            rtfTableRow.DocumentInternal = _table.DocumentInternal;

            rtfTableRow.Width = _table.Width;
            rtfTableRow.AlignInternal = _table.Align;

            foreach (var cell in rtfTableRow.Cells)
            {
                if (_table.ColumnCount > cell.ColumnIndexInternal)
                    cell.ColumnInternal = _table.Columns[cell.ColumnIndexInternal];
                
                if (!cell.Definition.HasStyle)
                {
                    if (cell.ColumnInternal != null && cell.ColumnInternal.DefaultCellStyle != null)
                        _table.Columns[cell.ColumnIndexInternal].DefaultCellStyle.CopyTo(cell.Definition.StyleInternal);
                    else if (_table.DefaultCellStyle != null)
                        _table.DefaultCellStyle.CopyTo(cell.Definition.StyleInternal);
                }

                if (!cell.Definition.IsWidthSet)
                {
                    if (cell.ColumnInternal != null && cell.ColumnInternal.IsWidthSet)
                        cell.Definition.Width = cell.ColumnInternal.Width;
                }
            }
        }
        

        void ICollection<RtfTableRow>.Clear()
        {

        }

        bool ICollection<RtfTableRow>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<RtfTableRow>.Remove(RtfTableRow item)
        {
            return false;
        }

        IEnumerator<RtfTableRow> IEnumerable<RtfTableRow>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}