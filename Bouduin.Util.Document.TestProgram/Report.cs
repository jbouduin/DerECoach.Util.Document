using System.Drawing;
using Bouduin.Util.Document.Generic.Contents.Image;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Document;
using Bouduin.Util.Document.Generic.Formatting;
using Bouduin.Util.Document.Primitives;
//using Bouduin.Util.Document.Rtf.Contents.Table;

namespace Bouduin.Util.Document.TestProgramm
{
    public class Report
    {
        private readonly IDocument _rtf;
        
        public Report()
        {
            _rtf = Factory.CreateDocument();
            var calibri = _rtf.AddFont("Calibri");
            var constantia = _rtf.AddFont("Constantia");
            var red = _rtf.AddColor(Color.Red);
            var blue =_rtf.AddColor(0, 0, 255);
            var twipConverter = Factory.CreateTwipConverter();
            //var LeftAligned12 = RtfParagraphFormatting(12, RtfTextAlign.Left);
            //var Centered10 = RtfParagraphFormatting(10, RtfTextAlign.Center);

            var header = Factory.CreateFormattedParagraph(16, ETextAlign.Center);
            
            //var t = RtfTable(RtfTableAlign.Center, 2, 3);

            header.Formatting.SpaceAfter = twipConverter.ToTwip(12F, EMetricUnit.Point);
            header.Formatting.FontIndex = calibri;
            header.AppendText("Calibri ");
            header.AppendText(Factory.CreateFormattedText(ECharacterFormatting.Bold,"Bold"));

            //t.Width = TwipConverter.ToTwip(5, EMetricUnit.Centimeter);
            //t.Columns[1].Width = TwipConverter.ToTwip(2, EMetricUnit.Centimeter);

            //foreach (var row in t.Rows)
            //{
            //    row.Height = TwipConverter.ToTwip(2, EMetricUnit.Centimeter);
            //}

            //t.MergeCellsVertically(1, 0, 2);

            //t.DefaultCellStyle = RtfTableCellStyle(RtfBorderSetting.None, Centered10);

            //t[0, 0].Definition.Style = RtfTableCellStyle(RtfBorderSetting.None, LeftAligned12, RtfTableCellVerticalAlign.Bottom);
            //t[0, 0].AppendText("Bottom");

            //t[1, 0].Definition.Style = RtfTableCellStyle(RtfBorderSetting.Left, Centered10, RtfTableCellVerticalAlign.Center, RtfTableCellTextFlow.BottomToTopLeftToRight);
            //t[1, 1].Definition.Style = t[1, 0].Definition.Style;
            //t[1, 0].AppendText("Vertical");

            //t[0, 1].Formatting = RtfParagraphFormatting(10, RtfTextAlign.Center);
            //t[0, 1].Formatting.TextColorIndex = 1;
            //t[0, 1].AppendText(RtfFormattedText("Black ", 0));
            //t[0, 1].AppendText("Red ");
            //t[0, 1].AppendText(RtfFormattedText("Blue", 2));

            //t[0, 2].AppendText("Normal");
            //t[1, 2].AppendText(RtfFormattedText("Italic", RtfCharacterFormatting.Caps | RtfCharacterFormatting.Italic));
            //t[1, 2].AppendParagraph("+");
            //t[1, 2].AppendParagraph(RtfFormattedText("Caps", RtfCharacterFormatting.Caps | RtfCharacterFormatting.Italic));

            var p1 = Factory.CreateFormattedParagraph(12, ETextAlign.Left);
            p1.Formatting.FontIndex = constantia;
            p1.Formatting.IndentLeft = twipConverter.ToTwip(6.05F, EMetricUnit.Centimeter);
            p1.Formatting.SpaceBefore = twipConverter.ToTwip(6F, EMetricUnit.Point);
            p1.AppendText("Constantia ");
            p1.AppendText(Factory.CreateFormattedText(ECharacterFormatting.Superscript, "Superscript"));
            p1.AppendParagraph(Factory.CreateFormattedText(-1, 8, "Inline"));
            p1.AppendText(Factory.CreateFormattedText(-1, 14, " font size "));
            p1.AppendText(Factory.CreateFormattedText(-1, 8, "change"));
            
            var picture = Factory.CreateDocumentImage(Properties.Resources.lemon, EImageFormat.Wmf);
            picture.ScaleX = 50;
            picture.ScaleY = 50;

            p1.AppendParagraph(picture);

            var linkText = Factory.CreateFormattedText(ECharacterFormatting.Underline, 2, "View article");
            linkText.BackgroundColorIndex = blue;
            p1.AppendParagraph(Factory.CreateHyperlink("http://www.codeproject.com/KB/cs/RtfConstructor.aspx", linkText));

            var p2 = Factory.CreateFormattedParagraph();
            p2.Formatting.FontSize = 10;
            
            p2.Tabs.Add(Factory.CreateTab(twipConverter.ToTwip(2.5F, EMetricUnit.Centimeter), ETabKind.Decimal));
            p2.Tabs.Add(Factory.CreateTab(twipConverter.ToTwip(5F, EMetricUnit.Centimeter), ETabKind.FlushRight, ETabLead.Dots));
            p2.Tabs.Add(Factory.CreateTab(twipConverter.ToTwip(7.5F, EMetricUnit.Centimeter)));
            p2.Tabs.Add(Factory.CreateTab(twipConverter.ToTwip(10F, EMetricUnit.Centimeter), ETabKind.Centered));
            p2.Tabs.Add(Factory.CreateTab(twipConverter.ToTwip(15F, EMetricUnit.Centimeter), ETabLead.Hyphens));

            p2.Tabs[2].Bar = true;

            p2.AppendText("One");
            p2.AppendText(Factory.CreateTabCharacter());
            p2.AppendText("Two");
            p2.AppendText(Factory.CreateTabCharacter());
            p2.AppendText("Three");
            p2.AppendText(Factory.CreateTabCharacter());
            p2.AppendText("Five");
            p2.AppendText(Factory.CreateTabCharacter());
            p2.AppendText("Six");

            //_rtf.Contents.AddRange(ARtfDocumentContent[] {
            //    header,
            //    t,
            //    p1,
            //    p2,
            //});
            _rtf.Contents.Add(header);
            //_rtf.Contents.Add(t);
            _rtf.Contents.Add(p1);
            _rtf.Contents.Add(p2);
        }

        public IDocument GetRtf()
        {
            return _rtf;
        }
    }
}