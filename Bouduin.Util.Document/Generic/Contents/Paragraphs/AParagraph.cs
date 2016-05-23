using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    internal abstract class AParagraph : ADocumentContent, IBaseParagraph, IRootDocumentContent, IChildDocumentContent
    {
        private bool _isPartOfATable;

        [RtfSortIndex(0), RtfControlWord("intbl")]
        public bool IsPartOfATable
        {
            get { return _isPartOfATable; }
            set { _isPartOfATable = value; }
        }

        [RtfSortIndex(100), RtfInclude]
        public ObservableCollection<IParagraphContent> Contents { get; private set; }

        [RtfSortIndex(110), RtfInclude]
        public ObservableCollection<IBaseParagraph> Paragraphs { get; private set; }

        protected AParagraph()
        {
            Contents = new ObservableCollection<IParagraphContent>();
            Contents.CollectionChanged += Contents_CollectionChanged;
            Paragraphs = new ObservableCollection<IBaseParagraph>();
            Paragraphs.CollectionChanged +=Paragraphs_CollectionChanged;
        }

        void Paragraphs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var newItem in e.NewItems.OfType<IBaseParagraph>())
                {
                    newItem.SetParent(this);
                }

            }
        }

        void Contents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var newItem in e.NewItems.OfType<IChildDocumentContent>())
                {
                    newItem.SetParent(this);
                }
                
            }
        }

        /// <param name="text">Text to add to paragraph contents.</param>
        protected AParagraph(string text) : this()
        {
            AppendText(text);
        }

        /// <param name="paragraphContent">Text to add to paragraph contents.</param>
        protected AParagraph(IParagraphContent paragraphContent) : this()
        {
            AppendText(paragraphContent);
        }


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
                Contents.Add(text);
            }
            else
            {
                Paragraphs[Paragraphs.Count - 1].AppendText(text);
            }
        }

        /// <summary>
        /// Add an empty paragraph with inherited formatting
        /// </summary>
        public void AppendParagraph()
        {
            Paragraphs.Add(new Paragraph());
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
            Paragraphs.Add(paragraph);
        }
        
        public abstract IParagraphFormatting GetFormatting();
    }
}