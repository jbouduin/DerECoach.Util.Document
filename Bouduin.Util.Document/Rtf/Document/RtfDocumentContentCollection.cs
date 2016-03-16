using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Document
{
    /// <summary>
    /// Represents a collection of RTF document contents.
    /// </summary>
    public class RtfDocumentContentCollection : ICollection<ARtfDocumentContent>, IEnumerable<ARtfDocumentContent>
    {
        private readonly RtfDocument Document;
        private readonly List<ARtfDocumentContent> list;

        /// <summary>
        /// Gets or sets ESCommon.Rtf.RtfDocumentContentBase at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfDocumentContentBase to get or set.</param>
        public ARtfDocumentContent this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }


        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfDocumentContentCollection class.
        /// </summary>
        /// <param name="document">Owning document.</param>
        internal RtfDocumentContentCollection(RtfDocument document)
        {
            list = new List<ARtfDocumentContent>();
            Document = document;
        }


        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfDocumentContentBase to the collection.
        /// </summary>
        public void Add(ARtfDocumentContent item)
        {
            list.Add(item);
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
            list.Clear();
        }

        /// <summary>
        /// Determines if an element is in the collection.
        /// </summary>
        /// <param name="item">An instance of ESCommon.Rtf.RtfDocumentContentBase to locate in the collection.</param>
        public bool Contains(ARtfDocumentContent item)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(ARtfDocumentContent[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes specified font from the collection.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        public bool Remove(ARtfDocumentContent item)
        {
            return list.Remove(item);
        }


        private void OnAddingItem(ARtfDocumentContent item)
        {
            item.DocumentInternal = Document;
        }


        bool ICollection<ARtfDocumentContent>.IsReadOnly
        {
            get { return false; }
        }

        IEnumerator<ARtfDocumentContent> IEnumerable<ARtfDocumentContent>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}