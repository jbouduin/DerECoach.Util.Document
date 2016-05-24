using System;

namespace Bouduin.Util.Document.Generic.Document
{

    internal abstract class ADocumentContent : IDocumentContentInternal
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

        #region IDocumentContentInternal members ------------------------------
        
        public virtual IDocument DocumentInternal
        {
            set { _document = value; }
        }

        public virtual IDocumentContent ParentInternal
        {
            set { _parent = value; }
        }
        #endregion
    }
}
