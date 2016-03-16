using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Header
{
    /// <summary>
    /// Represents a collection of ESCommon.Rtf.RtfFont in the header of a RTF document.
    /// </summary>
    public class RtfFontCollection: ICollection<RtfFont>
    {
        private readonly List<RtfFont> _list;
        
        /// <summary>
        /// Gets or sets ESCommon.Rtf.RtfFont at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfFont to get or set.</param>
        public RtfFont this[int index]
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
        /// Initializes a new instance of ESCommon.Rtf.RtfFontCollection class.
        /// </summary>
        internal RtfFontCollection()
        {
            _list = new List<RtfFont>();
        }


        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfFont to the collection.
        /// </summary>
        public void Add(RtfFont rtfFont)
        {
            _list.Add(rtfFont);
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfFont objects to the collection.
        /// </summary>
        public void AddRange(RtfFont[] fonts)
        {
            foreach (var font in fonts)
            {
                Add(font);
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
        /// <param name="rtfFont">An instance of ESCommon.Rtf.RtfFont to locate in the collection.</param>
        public bool Contains(RtfFont rtfFont)
        {
            return _list.Contains(rtfFont);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(RtfFont[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes specified font from the collection.
        /// </summary>
        /// <param name="rtfFont">Font to remove.</param>
        public bool Remove(RtfFont rtfFont)
        {
            return _list.Remove(rtfFont);
        }


        bool ICollection<RtfFont>.IsReadOnly
        {
            get { return false; }
        }

        IEnumerator<RtfFont> IEnumerable<RtfFont>.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}