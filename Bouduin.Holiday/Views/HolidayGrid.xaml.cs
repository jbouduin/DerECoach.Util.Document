using Bouduin.Holiday.ViewModels.HolidayGrid;

namespace Bouduin.Holiday.Views
{
    /// <summary>
    /// Interaction logic for HolidayGrid.xaml
    /// </summary>
    internal partial class HolidayGrid
    {
        public HolidayGrid()
        {
            InitializeComponent();
        }

        public HolidayGrid(IHolidayGridViewModel holidayGridViewModel)
        {
            InitializeComponent();
            DataContext = holidayGridViewModel;
        }
    }
}
