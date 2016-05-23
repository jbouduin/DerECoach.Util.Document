using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using Bouduin.Util.Common.Extensions;
using Bouduin.Util.Document.Generic.Header;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Document
{
    
    /// <summary>
    /// Represents a document.
    /// </summary>
    [RtfControlWord("rtf1"), RtfEnclosingBraces]
    internal class Document: IDocument
    {
        #region fields --------------------------------------------------------
        private EDocumentCharacterSet _charSet = EDocumentCharacterSet.ANSI;
        private ECodePage _codePage = ECodePage.WesternEuropean;
        private readonly List<IDocumentFont> _fontTable = new List<IDocumentFont>();
        private readonly List<IDocumentColor> _colorTable = new List<IDocumentColor>{DocumentColor.Auto};
        #endregion

        #region IRtfDocumentInterface -----------------------------------------
        [RtfSortIndex(0), RtfControlWord]
        public EDocumentCharacterSet CharSet
        {
            get { return _charSet; }
            set { _charSet = value; }
        }

        [RtfSortIndex(1), RtfControlWord]
        public ECodePage CodePage
        {
            get { return _codePage; }
            set { _codePage = value; }
        }

        [RtfSortIndex(2), RtfControlWord("deffont"), RtfIndex, RtfInclude(ConditionMember = "FontTableIsNotEmpty")]
        public int DefaultFont { get; set; }

        [RtfSortIndex(3), RtfControlWord("deflang")]
        public ELanguage DefaultLanguage { get; set; }

        [RtfSortIndex(100), RtfInclude]
        public ObservableCollection<IDocumentContent> Contents { get; protected set; }
        #endregion

        #region IDocument members ---------------------------------------------
        public int AddFont(string fontName)
        {
            var newFont = new DocumentFont(fontName);
            if (!FontTable.Contains(newFont))
                FontTable.Add(new DocumentFont(fontName));

            return FontTable.IndexOf(newFont);
        }

        public int AddFont(string fontName, ECharacterSet characterSet)
        {
            var newFont = new DocumentFont(fontName, characterSet);
            if (!FontTable.Contains(newFont))
                FontTable.Add(new DocumentFont(fontName));

            return FontTable.IndexOf(newFont);
        }

        public int AddFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily)
        {
            var newFont = new DocumentFont(fontName, characterSet, fontFamily);
            if (!FontTable.Contains(newFont))
                FontTable.Add(new DocumentFont(fontName));

            return FontTable.IndexOf(newFont);
        }

        public int AddFont(string fontName, ECharacterSet characterSet, EFontFamily fontFamily, EFontPitch fontPitch)
        {
            var newFont = new DocumentFont(fontName, characterSet, fontFamily, fontPitch);
            if (!FontTable.Contains(newFont))
                FontTable.Add(new DocumentFont(fontName));

            return FontTable.IndexOf(newFont);
        }

        public int AddColor(Color color)
        {
            var newColor = new DocumentColor(color);
            if (!ColorTable.Contains(newColor))
                ColorTable.Add(newColor);

            return ColorTable.IndexOf(newColor);
        }

        public int AddColor(int red, int green, int blue)
        {
            var newColor = new DocumentColor(red, green, blue);
            if (!ColorTable.Contains(newColor))
                ColorTable.Add(newColor);

            return ColorTable.IndexOf(newColor);
        }
        
        #endregion

        #region properties ----------------------------------------------------
        [RtfSortIndex(4), RtfControlGroup("fonttbl"), RtfInclude(ConditionMember = "FontTableIsNotEmpty")]
        public List<IDocumentFont> FontTable
        {
            get { return _fontTable; }
        }

        [RtfSortIndex(5), RtfControlGroup("colortbl")]
        public List<IDocumentColor> ColorTable
        {
            get { return _colorTable; }
        }
        
        public bool FontTableIsNotEmpty
        {
            get { return !FontTable.IsNullOrEmpty(); }
        }
        #endregion

        #region constructor ---------------------------------------------------
        public Document()
        {
            Contents = new ObservableCollection<IDocumentContent>();
            Contents.CollectionChanged += Contents_CollectionChanged;
            DefaultLanguage = ELanguage.EnglishUnitedStates;
        }
        #endregion

        #region collection event ----------------------------------------------
        void Contents_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var newItem in e.NewItems)
                {
                    if (newItem is IRootDocumentContent)
                        (newItem as IRootDocumentContent).SetDocument(this);
                    else
                        throw new Exception("Only IRootDocumentContent can be added");
                }
            }
        }

        public Document(ECodePage codePage) : this()
        {
            CodePage = codePage;
        }
        #endregion
    }
}