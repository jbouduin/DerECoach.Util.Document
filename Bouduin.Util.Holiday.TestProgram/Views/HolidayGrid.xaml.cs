using Bouduin.Util.Holiday.TestProgram.ViewModels.HolidayGrid;

namespace Bouduin.Util.Holiday.TestProgram.Views
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
