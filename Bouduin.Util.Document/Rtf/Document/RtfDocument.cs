using System.Drawing;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Attributes;
using Bouduin.Util.Document.Rtf.Header;

namespace Bouduin.Util.Document.Rtf.Document
{
    public interface IDocument
    {
        int AddFont(string fontName);
        int AddColor(Color color);
        int AddColor(int red, int green, int blue);

        RtfDocumentContentCollection Contents { get; }
    }

    public class DocumentFactory
    {
        public static IDocument CreateDocument()
        {
            return new RtfDocument();
        }

        public static IDocument CreateDocument(ECodePage codePage)
        {
            return new RtfDocument(codePage);
        }

    }

    public abstract class ADocument : IDocument
    {
        #region IRtfDocumentInterface -----------------------------------------

        public abstract int AddFont(string fontName);

        public abstract int AddColor(Color color);

        public abstract int AddColor(int red, int green, int blue);

        public abstract RtfDocumentContentCollection Contents { get; }

        #endregion

    }

    /// <summary>
    /// Represents a RTF document.
    /// </summary>
    [RtfControlWord("rtf1"), RtfEnclosingBraces]
    public class RtfDocument: ADocument
    {
        #region fields --------------------------------------------------------
        private ERtfDocumentCharacterSet _charSet = ERtfDocumentCharacterSet.ANSI;
        private ECodePage _codePage = ECodePage.WesternEuropean;
        private ERtfLanguage _defaultLanguage = ERtfLanguage.EnglishUnitedStates;
        private readonly RtfFontCollection _fontTable = new RtfFontCollection();
        private readonly RtfColorCollection _colorTable = new RtfColorCollection();
        private readonly RtfDocumentContentCollection _contents;
        #endregion

        #region IRtfDocumentInterface -----------------------------------------
        [RtfControlWord]
        public ERtfDocumentCharacterSet CharSet
        {
            get { return _charSet; }
            set { _charSet = value; }
        }

        [RtfControlWord]
        public ECodePage CodePage
        {
            get { return _codePage; }
            set { _codePage = value; }
        }

        [RtfControlWord("deffont"), RtfIndex, RtfInclude(ConditionMember = "FontTableIsNotEmpty")]
        public int DefaultFont { get; set; }

        [RtfControlWord("deflang")]
        public ERtfLanguage DefaultLanguage
        {
            get { return _defaultLanguage; }
            set { _defaultLanguage = value; }
        }
        #endregion

        #region abstract basemembers implementation ---------------------------
        // TODO 
        public override int AddFont(string fontName)
        {
            FontTable.Add(new RtfFont(fontName));
            return 0;
        }

        public override int AddColor(Color color)
        {
            ColorTable.Add(new RtfColor(color));
            return 0;
        }

        public override int AddColor(int red, int green, int blue)
        {
            ColorTable.Add(new RtfColor(red, green, blue));
            return 0;
        }

        [RtfInclude]
        public override RtfDocumentContentCollection Contents
        {
            get { return _contents; }
        }
        #endregion

        #region properties ----------------------------------------------------
        [RtfControlGroup("fonttbl"), RtfInclude(ConditionMember = "FontTableIsNotEmpty")]
        public RtfFontCollection FontTable
        {
            get { return _fontTable; }
        }

        [RtfControlGroup("colortbl")]
        public RtfColorCollection ColorTable
        {
            get { return _colorTable; }
        }

        

        public bool FontTableIsNotEmpty
        {
            // TODO add IfNotNull extensions
            get { return FontTable != null && FontTable.Count > 0; }
        }
        #endregion

        
        
        

        #region constructor ---------------------------------------------------
        public RtfDocument()
        {
            _contents = new RtfDocumentContentCollection(this);
        }

        public RtfDocument(ECodePage codePage) : this()
        {
            CodePage = codePage;
        }
        #endregion
    }
}