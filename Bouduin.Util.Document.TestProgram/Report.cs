using System.Drawing;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Contents;
using Bouduin.Util.Document.Rtf.Contents.Paragraphs;
using Bouduin.Util.Document.Rtf.Contents.Table;
using Bouduin.Util.Document.Rtf.Contents.Text;
using Bouduin.Util.Document.Rtf.Document;
using Bouduin.Util.Document.Rtf.Formatting;
using Bouduin.Util.Document.Rtf.Header;

namespace Bouduin.Util.Document.TestProgramm
{
    public class Report
    {
        private readonly IDocument _rtf;
        
        public Report()
        {
            _rtf = DocumentFactory.CreateDocument();
            _rtf.AddFont("Calibri");
            _rtf.AddFont("Constantia");
            _rtf.AddColor(Color.Red);
            _rtf.AddColor(0, 0, 255);

            var LeftAligned12 = new RtfParagraphFormatting(12, RtfTextAlign.Left);
            var Centered10 = new RtfParagraphFormatting(10, RtfTextAlign.Center);

            var header = new RtfFormattedParagraph(new RtfParagraphFormatting(16, RtfTextAlign.Center));
            var p1 = new RtfFormattedParagraph(new RtfParagraphFormatting(12, RtfTextAlign.Left));

            var t = new RtfTable(RtfTableAlign.Center, 2, 3);

            header.Formatting.SpaceAfter = TwipConverter.ToTwip(12F, EMetricUnit.Point);
            header.AppendText("Calibri ");
            header.AppendText(new RtfFormattedText("Bold", RtfCharacterFormatting.Bold));

            t.Width = TwipConverter.ToTwip(5, EMetricUnit.Centimeter);
            t.Columns[1].Width = TwipConverter.ToTwip(2, EMetricUnit.Centimeter);

            foreach (var row in t.Rows)
            {
                row.Height = TwipConverter.ToTwip(2, EMetricUnit.Centimeter);
            }

            t.MergeCellsVertically(1, 0, 2);

            t.DefaultCellStyle = new RtfTableCellStyle(RtfBorderSetting.None, Centered10);

            t[0, 0].Definition.Style = new RtfTableCellStyle(RtfBorderSetting.None, LeftAligned12, RtfTableCellVerticalAlign.Bottom);
            t[0, 0].AppendText("Bottom");

            t[1, 0].Definition.Style = new RtfTableCellStyle(RtfBorderSetting.Left, Centered10, RtfTableCellVerticalAlign.Center, RtfTableCellTextFlow.BottomToTopLeftToRight);
            t[1, 1].Definition.Style = t[1, 0].Definition.Style;
            t[1, 0].AppendText("Vertical");

            t[0, 1].Formatting = new RtfParagraphFormatting(10, RtfTextAlign.Center);
            t[0, 1].Formatting.TextColorIndex = 1;
            t[0, 1].AppendText(new RtfFormattedText("Black ", 0));
            t[0, 1].AppendText("Red ");
            t[0, 1].AppendText(new RtfFormattedText("Blue", 2));

            t[0, 2].AppendText("Normal");
            t[1, 2].AppendText(new RtfFormattedText("Italic", RtfCharacterFormatting.Caps | RtfCharacterFormatting.Italic));
            t[1, 2].AppendParagraph("+");
            t[1, 2].AppendParagraph(new RtfFormattedText("Caps", RtfCharacterFormatting.Caps | RtfCharacterFormatting.Italic));

            p1.Formatting.FontIndex = 1;
            p1.Formatting.IndentLeft = TwipConverter.ToTwip(6.05F, EMetricUnit.Centimeter);
            p1.Formatting.SpaceBefore = TwipConverter.ToTwip(6F, EMetricUnit.Point);
            p1.AppendText("Constantia ");
            p1.AppendText(new RtfFormattedText("Superscript", RtfCharacterFormatting.Superscript));
            p1.AppendParagraph(new RtfFormattedText("Inline", -1, 8));
            p1.AppendText(new RtfFormattedText(" font size ", -1, 14));
            p1.AppendText(new RtfFormattedText("change", -1, 8));
            
            var picture = new RtfImage(Properties.Resources.lemon, RtfImageFormat.Wmf);
            picture.ScaleX = 50;
            picture.ScaleY = 50;

            p1.AppendParagraph(picture);

            var linkText = new RtfFormattedText("View article", RtfCharacterFormatting.Underline, 2);
            linkText.BackgroundColorIndex = 1;
            p1.AppendParagraph(new RtfHyperlink("http://www.codeproject.com/KB/cs/RtfConstructor.aspx", linkText));

            var p2 = new RtfFormattedParagraph();
            p2.Formatting = new RtfParagraphFormatting(10);
            
            p2.Tabs.Add(new RtfTab(TwipConverter.ToTwip(2.5F, EMetricUnit.Centimeter), RtfTabKind.Decimal));
            p2.Tabs.Add(new RtfTab(TwipConverter.ToTwip(5F, EMetricUnit.Centimeter), RtfTabKind.FlushRight, RtfTabLead.Dots));
            p2.Tabs.Add(new RtfTab(TwipConverter.ToTwip(7.5F, EMetricUnit.Centimeter)));
            p2.Tabs.Add(new RtfTab(TwipConverter.ToTwip(10F, EMetricUnit.Centimeter), RtfTabKind.Centered));
            p2.Tabs.Add(new RtfTab(TwipConverter.ToTwip(15F, EMetricUnit.Centimeter), RtfTabLead.Hyphens));

            p2.Tabs[2].Bar = true;

            p2.AppendText("One");
            p2.AppendText(new RtfTabCharacter());
            p2.AppendText("Two");
            p2.AppendText(new RtfTabCharacter());
            p2.AppendText("Three");
            p2.AppendText(new RtfTabCharacter());
            p2.AppendText("Five");
            p2.AppendText(new RtfTabCharacter());
            p2.AppendText("Six");

            _rtf.Contents.AddRange(new ARtfDocumentContent[] {
                header,
                t,
                p1,
                p2,
            });
        }

        public IDocument GetRtf()
        {
            return _rtf;
        }
    }
}