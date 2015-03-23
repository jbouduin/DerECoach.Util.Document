
using Bouduin.Lib.Holiday;

namespace Bouduin.Holiday
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var test = Service.GetSupportedLocations();
        }
    }
}
