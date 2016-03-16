using Bouduin.Util.Holiday.TestProgram.ViewModels.HolidayGrid;
using Bouduin.Util.Holiday.TestProgram.ViewModels.LocationTree;
using Bouduin.Util.Holiday.TestProgram.ViewModels.MainWindow;
using Bouduin.Util.Holiday.TestProgram.Views;

namespace Bouduin.Util.Holiday.TestProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var holidayGridViewModel = new HolidayGridViewModel();
            var locationTreeViewModel = new LocationTreeViewModel(holidayGridViewModel);
            DataContext = new MainWindowViewModel(locationTreeViewModel);
            TreeViewGrid.Children.Add(new LocationTreeView(locationTreeViewModel));
            ContentGrid.Children.Add(new HolidayGrid(holidayGridViewModel));

        }

        
    }
}
