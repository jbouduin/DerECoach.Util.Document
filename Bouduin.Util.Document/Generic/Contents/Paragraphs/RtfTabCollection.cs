using System;
using System.Collections;
using System.Collections.Generic;

namespace Bouduin.Util.Document.Rtf.Contents.Paragraphs
{
    /// <summary>
    /// Represents a collection of ESCommon.Rtf.RtfTab within a paragraph.
    /// </summary>
    public class RtfTabCollection: ICollection<RtfTab>
    {
        private readonly List<RtfTab> _list;

        /// <summary>
        /// Gets or sets ESCommon.Rtf.RtfTab at specified location.
        /// </summary>
        /// <param name="index">A zero-based index of ESCommon.Rtf.RtfTab to get or set.</param>
        public RtfTab this[int index]
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


        internal RtfTabCollection()
        {
            _list = new List<RtfTab>();
        }


        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTab to the collection.
        /// </summary>
        public void Add(RtfTab rtfTab)
        {
            OnAddingTab(rtfTab);

            _list.Add(rtfTab);
        }

        /// <summary>
        /// Adds the specified ESCommon.Rtf.RtfTab objects to the collection.
        /// </summary>
        public void AddRange(RtfTab[] rtfTabs)
        {
            foreach (var tab in rtfTabs)
            {
                Add(tab);
            }
        }

        /// <summary>
        /// Clears all the contents of the collection.
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        
        public bool Contains(RtfTab rtfTab)
        {
            return _list.Contains(rtfTab);
        }

        /// <summary>
        /// Copies the entire collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(RtfTab[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }



        private void OnAddingTab(RtfTab rtfTab)
        {
            if (rtfTab == null)
                throw (new ArgumentNullException("RtfTab cannot be null"));

            foreach (var t in _list)
            {
                if (t.Position == rtfTab.Position)
                {
                    throw (new InvalidOperationException("Cannot insert two tabs at one position"));
                }
            }
        }



        bool ICollection<RtfTab>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection<RtfTab>.Remove(RtfTab item)
        {
            return false;
        }

        public IEnumerator<RtfTab> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}