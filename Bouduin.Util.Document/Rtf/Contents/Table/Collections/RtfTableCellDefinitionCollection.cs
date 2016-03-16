using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Contents.Table.Collections
{
    /// <summary>
    /// Represents a collection of cell definitions in a ESCommon.Rtf.RtfTableRow
    /// </summary>
    public class RtfTableCellDefinitionCollection : IEnumerable<RtfTableCellDefinition>
    {
        private RtfTableRow _row;
        private readonly List<RtfTableCellDefinition> _list;

        /// <summary>
        /// Gets ESCommon.Rtf.RtfTableCellDefinition at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfTableCellDefinition to get.</param>
        public RtfTableCellDefinition this[int index]
        {
            get { return _list[index]; }
        }

        /// <summary>
        /// Gets the number of cell definitions in the collection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCellDefinitionCollection class.
        /// </summary>
        /// <param name="row">Owning row.</param>
        internal RtfTableCellDefinitionCollection(RtfTableRow row)
        {
            _list = new List<RtfTableCellDefinition>();
            _row = row;
        }


        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTableCellDefinition to the collection.
        /// </summary>
        internal void AddInternal(RtfTableCellDefinition rtfTableCellDefinition)
        {
            _list.Add(rtfTableCellDefinition);
        }


        IEnumerator<RtfTableCellDefinition> IEnumerable<RtfTableCellDefinition>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

    }
}