using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Document
{
    /// <summary>
    /// Represents a collection of RTF document contents.
    /// </summary>
    public class RtfDocumentContentCollection : ICollection<ARtfDocumentContent>
    {
        private readonly RtfDocument _document;
        private readonly List<ARtfDocumentContent> _list;

        /// <summary>
        /// Gets or sets ESCommon.Rtf.RtfDocumentContentBase at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ARtfDocumentContent to get or set.</param>
        public ARtfDocumentContent this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfDocumentContentCollection class.
        /// </summary>
        /// <param name="document">Owning document.</param>
        internal RtfDocumentContentCollection(RtfDocument document)
        {
            _list = new List<ARtfDocumentContent>();
            _document = document;
        }


        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfDocumentContentBase to the collection.
        /// </summary>
        public void Add(ARtfDocumentContent item)
        {
            _list.Add(item);
            OnAddingItem(item);
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfDocumentContentBase objects to the collection.
        /// </summary>
        public void AddRange(ARtfDocumentContent[] items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Clears all the contents of the collection.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        /// Determines if an element is in the collection.
        /// </summary>
        /// <param name="item">An instance of ESCommon.Rtf.RtfDocumentContentBase to locate in the collection.</param>
        public bool Contains(ARtfDocumentContent item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(ARtfDocumentContent[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes specified font from the collection.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        public bool Remove(ARtfDocumentContent item)
        {
            return _list.Remove(item);
        }


        private void OnAddingItem(ARtfDocumentContent item)
        {
            item.DocumentInternal = _document;
        }


        bool ICollection<ARtfDocumentContent>.IsReadOnly
        {
            get { return false; }
        }

        IEnumerator<ARtfDocumentContent> IEnumerable<ARtfDocumentContent>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}