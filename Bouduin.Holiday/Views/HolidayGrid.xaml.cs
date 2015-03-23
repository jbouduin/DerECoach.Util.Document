using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bouduin.Holiday.ViewModels.HolidayGrid;

namespace Bouduin.Holiday.Views
{
    /// <summary>
    /// Interaction logic for HolidayGrid.xaml
    /// </summary>
    internal partial class HolidayGrid : UserControl
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
