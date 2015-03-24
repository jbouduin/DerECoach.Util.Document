
using Bouduin.Holiday.ViewModels.HolidayGrid;
using Bouduin.Holiday.ViewModels.LocationTree;
using Bouduin.Holiday.ViewModels.MainWindow;
using Bouduin.Holiday.Views;

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
            
            var holidayGridViewModel = new HolidayGridViewModel();
            var locationTreeViewModel = new LocationTreeViewModel(holidayGridViewModel);
            DataContext = new MainWindowViewModel(locationTreeViewModel);
            TreeViewGrid.Children.Add(new LocationTreeView(locationTreeViewModel));
            ContentGrid.Children.Add(new HolidayGrid(holidayGridViewModel));

        }

        
    }
}
