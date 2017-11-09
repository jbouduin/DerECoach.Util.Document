using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Rtf;

namespace Bouduin.Util.Document.TestProgramm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
    
            var report = new Report();
            var rtf = report.GetRtf();
            var rtfWriter = new RtfWriter();
            DateTime start;
            TimeSpan time;

            try
            {
                using (TextWriter writer = new StreamWriter("test.rtf"))
                {
                    start = DateTime.Now;

                    rtfWriter.Write(writer, rtf);

                    time = DateTime.Now - start;

                    label1.Text = string.Format("{0}.{1}", time.Seconds, time.Milliseconds.ToString().PadLeft(3, '0'));
                }
            }
            catch (IOException)
            {
                label1.Text = @"I/O Exception";
            }
            Process.Start("test.rtf");
            button1.Enabled = true;
        }
    }
}