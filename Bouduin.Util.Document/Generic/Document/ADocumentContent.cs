using System;

namespace Bouduin.Util.Document.Generic.Document
{

    internal abstract class ADocumentContent : IDocumentContent
    {
        #region properties ----------------------------------------------------
        private IDocument _document;
        private IDocumentContent _parent;
        #endregion

        #region IDocumentContent members --------------------------------------
        public IDocument Document
        {
            get
            {
                return _document ?? Parent.Document;
            }
        }

        public IDocumentContent Parent
        {
            get { return _parent; }
        }
        #endregion
        
        public void SetDocument(IDocument document)
        {
            if (_document != null || _parent != null)
                throw new Exception("Content already belongs to a document");

            _document = document;
        }

        public void SetParent(IDocumentContent parentDocumentContent)
        {
            if (_parent != null)
                throw new Exception("Content already has a parent");

            if (_document != null)
                throw new Exception("Content is root content and can not have a parent");

            _parent = parentDocumentContent;
        }

    }
}
