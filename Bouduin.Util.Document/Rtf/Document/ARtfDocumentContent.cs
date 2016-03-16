namespace Bouduin.Util.Document.Rtf.Document
{
    
    public abstract class ARtfDocumentContent
    {
        protected RtfDocument Document;

        internal virtual RtfDocument DocumentInternal
        {
            get { return Document; }
            set { Document = value; }
        }
    }
}
