
namespace Bouduin.Util.Document.Generic.Document
{
    public interface IDocumentContent
    {
        IDocument Document { get; }
        IDocumentContent Parent { get; }
    }

    internal interface IRootDocumentContent
    {
        void SetDocument(IDocument document);
    }

    internal interface IChildDocumentContent
    {
        void SetParent(IDocumentContent parentDocumentContent);
    }
}