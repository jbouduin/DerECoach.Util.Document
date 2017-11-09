using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Factories;

namespace Bouduin.Util.Document
{
    // class is public so can be used using Unity
    public class Factory : IFactory
    {
        #region fields --------------------------------------------------------
        private readonly ITwipConverter _twipConverter = new TwipConverter();
        private ITableFactory _tableFactory;
        private IDocumentFactory _documentFactory;
        private IParagraphFactory _paragraphFactory;
        private ITextFactory _textFactory;
        private IImageFactory _imageFactory;
        #endregion

        #region IFactory members ----------------------------------------------
        public ITwipConverter TwipConverter
        {
            get { return _twipConverter; }
        }

        public ITableFactory TableFactory
        {
            get { return _tableFactory ?? (_tableFactory = new TableFactory(_twipConverter)); }
        }

        public IDocumentFactory DocumentFactory
        {
            get { return _documentFactory ?? (_documentFactory = new DocumentFactory()); }
        }

        public IParagraphFactory ParagraphFactory
        {
            get { return _paragraphFactory ?? (_paragraphFactory = new ParagraphFactory(_twipConverter)); }
        }

        public ITextFactory TextFactory
        {
            get { return _textFactory ?? (_textFactory = new TextFactory()); }
        }

        public IImageFactory ImageFactory
        {
            get { return _imageFactory ?? (_imageFactory = new ImageFactory(_twipConverter)); }
        }
        #endregion
        
        
        
    }
}