using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document.Factories
{
    public class DocumentFactory : IDocumentFactory
    {
        public IDocument CreateDocument()
        {
            return new Generic.Documents.Document();
        }

        public IDocument CreateDocument(ECodePage codePage)
        {
            return new Generic.Documents.Document(codePage);
        } 
    }
}