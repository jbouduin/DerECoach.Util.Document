using System.Drawing;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Factories;
using Bouduin.Util.Document.Generic.Contents.Image;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.SpecialCharacters;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Primitives;

namespace Bouduin.Util.Document
{
    public interface IFactory
    {
        ITwipConverter TwipConverter { get; }
        ITableFactory TableFactory { get; }
        IDocumentFactory DocumentFactory { get; }
        IParagraphFactory ParagraphFactory { get; }
        ITextFactory TextFactory { get; }
        IImageFactory ImageFactory { get; }
    }
}