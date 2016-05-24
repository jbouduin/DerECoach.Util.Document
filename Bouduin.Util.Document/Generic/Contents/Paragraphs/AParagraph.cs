using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    internal abstract class AParagraph : ADocumentContent, IBaseParagraphInternal
    {
        #region fields --------------------------------------------------------
        protected readonly ObservableCollection<IParagraphContent> ContentsInternal;
        protected readonly ObservableCollection<IBaseParagraph> ParagraphsInternal;
        #endregion

        #region IBaseParagraph properties -------------------------------------
        

        [RtfSortIndex(100), RtfInclude]
        public ReadOnlyCollection<IParagraphContent> Contents { get {return new ReadOnlyCollection<IParagraphContent>(ContentsInternal);} }

        [RtfSortIndex(110), RtfInclude]
        public ReadOnlyCollection<IBaseParagraph> Paragraphs { get {return new ReadOnlyCollection<IBaseParagraph>(ParagraphsInternal);} }
        #endregion

        #region IBaseParagraph methods ----------------------------------------
        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        public void AppendText(string text)
        {
            AppendText(new PlainText(text));
        }

        /// <summary>
        /// Add text to paragraph contents
        /// </summary>
        public void AppendText(IParagraphContent text)
        {
            if (Paragraphs.Count == 0)
            {
                ContentsInternal.Add(text);
            }
            else
            {
                ParagraphsInternal.Last().AppendText(text);
            }
        }

        /// <summary>
        /// Add an empty paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph()
        {
            ParagraphsInternal.Add(new Paragraph());
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(string text)
        {
            AppendParagraph(new Paragraph(text));
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(IParagraphContent text)
        {
            AppendParagraph(new Paragraph(text));
        }

        /// <summary>
        /// Add a new paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph(IBaseParagraph paragraph)
        {
            ParagraphsInternal.Add(paragraph);
        }
        #endregion

        #region IBaseParagraphInternal members --------------------------------
        [RtfSortIndex(0), RtfControlWord("intbl")]
        public bool IsPartOfATable { get; set; }
        
        #endregion

        #region abstract members ----------------------------------------------
        public abstract IParagraphFormatting GetFormatting();
        #endregion

        #region constructor ---------------------------------------------------
        protected AParagraph()
        {
            ContentsInternal = new ObservableCollection<IParagraphContent>();
            ContentsInternal.CollectionChanged += Contents_CollectionChanged;
            ParagraphsInternal = new ObservableCollection<IBaseParagraph>();
            ParagraphsInternal.CollectionChanged += Paragraphs_CollectionChanged;
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        protected AParagraph(string text)
            : this()
        {
            AppendText(text);
        }

        /// <param name="paragraphContent">Text to add to paragraph contents.</param>
        protected AParagraph(IParagraphContent paragraphContent)
            : this()
        {
            AppendText(paragraphContent);
        }
        #endregion

        #region observable collection events ----------------------------------
        void Paragraphs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var newItem in e.NewItems.OfType<IBaseParagraphInternal>())
                {
                    newItem.ParentInternal = this;
                }

            }
        }
        
        void Contents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var newItem in e.NewItems.OfType<IDocumentContentInternal>())
                {
                    newItem.ParentInternal = this;
                }
                
            }
        }
        #endregion

        


        
        
        

        
    }
}