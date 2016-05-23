using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bouduin.Util.Common.Extensions;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Paragraphs
{
    /// <summary>
    /// Represents a formatted paragraph.
    /// </summary>
    [RtfControlWord("pard"), RtfControlWordDenotingEnd("par")]
    internal class FormattedParagraph : AParagraph, IFormattedParagraph
    {
        #region fields --------------------------------------------------------

        private ELanguage _language = ELanguage.EnglishUnitedStates;
        private IParagraphFormatting _formatting = new ParagraphFormatting();
        private ObservableCollection<ITab> _tabs;
        private bool _isFormattingIncluded = true;
        private bool _resetFormatting;
        private readonly List<int> _existingTabPositions = new List<int>();
        #endregion

        #region IFormattedParagraph members -----------------------------------
        
        /// <summary>
        /// Gets or sets a Boolean value indicating that font (character) formatting is reset to default value
        /// </summary>
        [RtfSortIndex(1), RtfControlWord("plain")]
        public bool ResetFormatting
        {
            get { return _resetFormatting; }
            set { _resetFormatting = value; }
        }

        /// <summary>
        /// Gets or sets paragraph formatting
        /// </summary>
        [RtfSortIndex(2), RtfInclude(ConditionMember = "IsFormattingIncluded")]
        public IParagraphFormatting Formatting
        {
            get { return _formatting; }
            set { _formatting = value; }
        }

        /// <summary>
        /// Default language is English (United States).
        /// </summary>
        [RtfSortIndex(3), RtfControlWord, RtfInclude(ConditionMember = "IsNotDefaultLanguage")]
        public ELanguage Language
        {
            get { return _language; }
            set { _language = value; }
        }

        /// <summary>
        /// Gets an array of paragraph tabs.
        /// </summary>
        [RtfSortIndex(4), RtfInclude]
        public ObservableCollection<ITab> Tabs
        {
            get { return _tabs ?? (_tabs = CreateTabsCollection()); }
        }
        
        /// <summary>
        /// Condition member used by RtfWriter.
        /// </summary>
        public bool IsNotDefaultLanguage
        {
            get { return _language != Document.DefaultLanguage; }
        }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether RtfWriter must include formatting
        /// </summary>
        public bool IsFormattingIncluded
        {
            get { return _isFormattingIncluded; }
            set { _isFormattingIncluded = value; }
        }

        /// <summary>
        /// Clears all the contents of the paragraph.
        /// </summary>
        public void Clear()
        {
            Contents.Clear();
            Paragraphs.Clear();
        }
        #endregion

        #region base members override -----------------------------------------
        
        /// <summary>
        /// Returns IParagraphFormatting of the paragraph.
        /// </summary>
        public override IParagraphFormatting GetFormatting()
        {
            return _formatting;
        }
        #endregion 

        #region constructor ---------------------------------------------------
        public FormattedParagraph()
        {
        }

        /// <param name="text">Text to add to paragraph contents</param>
        public FormattedParagraph(string text) : base(text)
        {
        }

        /// <param name="text">Text to add to paragraph contents</param>
        public FormattedParagraph(ParagraphContent text) : base(text)
        {
        }

        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        public FormattedParagraph(float fontSize, ETextAlign align) 
        {
            _formatting = new ParagraphFormatting(fontSize, align);
        }

        /// <param name="align"></param>
        public FormattedParagraph(ETextAlign align)
        {
            _formatting = new ParagraphFormatting(align);
        }

        /// <param name="fontSize"></param>
        public FormattedParagraph(float fontSize)
        {
            _formatting = new ParagraphFormatting(fontSize);
        }

        /// <param name="text">Text to add to paragraph contents</param>
        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        public FormattedParagraph(string text, float fontSize, ETextAlign align)
            : base(text)
        {
            _formatting = new ParagraphFormatting(fontSize, align);
        }

        /// <param name="text">Text to add to paragraph contents</param>
        /// <param name="fontSize"></param>
        /// <param name="align"></param>
        public FormattedParagraph(IParagraphContent text, float fontSize, ETextAlign align)
            : base(text)
        {
            _formatting = new ParagraphFormatting(fontSize, align);
        }
        #endregion
        
        #region private helpers -----------------------------------------------
        private ObservableCollection<ITab> CreateTabsCollection()
        {
            var result = new ObservableCollection<ITab>();
            result.CollectionChanged += result_CollectionChanged;
            return result;
        }

        private void result_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems.IfNotNull(notNull => notNull.Count,0) > 0)
                throw new NotSupportedException();
            
            foreach (var newTab in e.NewItems.OfType<Tab>())
            {
                if (_existingTabPositions.Any(existingTab => existingTab == newTab.Position))
                {
                    throw (new InvalidOperationException("Cannot insert two tabs at one position"));
                }
                _existingTabPositions.Add(newTab.Position);
            }
        }
        #endregion
    }
}
