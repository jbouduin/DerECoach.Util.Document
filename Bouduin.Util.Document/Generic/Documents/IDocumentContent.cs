
namespace Bouduin.Util.Document.Generic.Documents
{
    public interface IDocumentContent
    {
        IDocument Document { get; }
        IDocumentContent Parent { get; }
    }

    public interface IDocumentContentInternal: IDocumentContent
    {
        IDocument DocumentInternal { set; }
        IDocumentContent ParentInternal { set; }
    }
    
}