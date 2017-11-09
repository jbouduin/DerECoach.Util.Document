using Bouduin.Util.Document.Generic.Documents;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    public interface IParagraphContent: IDocumentContent
    {
        
    }

    internal interface IParagraphContentInternal : IParagraphContent, IDocumentContentInternal
    {
        
    }
    /// <summary>
    /// Can be used within a paragraph
    /// </summary>
    internal abstract class ParagraphContent : ADocumentContent, IParagraphContentInternal
    {
        
    }
}
