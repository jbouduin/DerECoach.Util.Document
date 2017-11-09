using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Factories
{
    public interface IDocumentFactory
    {
        IDocument CreateDocument();
        IDocument CreateDocument(ECodePage codePage);
    }
}