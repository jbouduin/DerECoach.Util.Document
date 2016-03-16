using System;
using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Contents.Table.Collections
{
    /// <summary>
    /// Represents a collection of columns in a ESCommon.Rtf.RtfTable
    /// </summary>
    public class RtfTableColumnCollection : ICollection<RtfTableColumn>
    {
        private readonly RtfTable _table;
        private readonly List<RtfTableColumn> _list;

        /// <summary>
        /// Gets ESCommon.Rtf.RtfTableColumn at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfTableColumn to get.</param>
        public RtfTableColumn this[int index]
        {
            get { return _list[index]; }
        }

        /// <summary>
        /// Gets the number of columns in the collection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableColumnCollection class.
        /// </summary>
        /// <param name="table">Owning table.</param>
        internal RtfTableColumnCollection(RtfTable table)
        {
            _list = new List<RtfTableColumn>();
            _table = table;
        }
        
        /// <summary>
        /// Adds a new ESCommon.Rtf.RtfTableColumn to the collection.
        /// </summary>
        public void Add()
        {
            Add(new RtfTableColumn());
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableColumn to the collection.
        /// </summary>
        public void Add(RtfTableColumn rtfTableColumn)
        {
            OnAddingColumn(rtfTableColumn);

            var num = _list.Count;
                
            _list.Add(rtfTableColumn);

            rtfTableColumn.IndexInternal = num;

            foreach (var row in _table.Rows)
            {
                if (row.Cells.Count > num)
                    row.Cells[num].ColumnInternal = rtfTableColumn;
            }
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableColumn objects to the collection.
        /// </summary>
        public void AddRange(RtfTableColumn[] rtfTableColumns)
        {
            foreach (var column in rtfTableColumns)
            {
                if (column != null)
                    Add(column);
                else
                    Add(new RtfTableColumn());
            }
        }

        /// <summary>
        /// Determines if an element is in the collection.
        /// </summary>
        /// <param name="cell">An instance of ESCommon.Rtf.RtfTableColumn to locate in the collection.</param>
        public bool Contains(RtfTableColumn rtfTableColumn)
        {
            return _list.Contains(rtfTableColumn);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(RtfTableColumn[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        

        private void OnAddingColumn(RtfTableColumn rtfTableColumn)
        {
            if (rtfTableColumn == null)
                throw (new ArgumentNullException("RtfTableColumn cannot be null"));

            if (rtfTableColumn.TableInternal != null)
                throw (new InvalidOperationException("RtfTableColumn already belongs to a RtfTable"));

            rtfTableColumn.TableInternal = _table;
        }


        void ICollection<RtfTableColumn>.Clear()
        {
            
        }

        bool ICollection<RtfTableColumn>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<RtfTableColumn>.Remove(RtfTableColumn item)
        {
            return false;
        }

        IEnumerator<RtfTableColumn> IEnumerable<RtfTableColumn>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}