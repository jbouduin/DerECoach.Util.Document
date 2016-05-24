
namespace Bouduin.Util.Document.Generic.Document
{
    public interface IDocumentContent
    {
        IDocument Document { get; }
        IDocumentContent Parent { get; }
    }

    public interface IDocumentContentInternal
    {
        IDocument DocumentInternal { set; }
        IDocumentContent ParentInternal { set; }
    }
    
}