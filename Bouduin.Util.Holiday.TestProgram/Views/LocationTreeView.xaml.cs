
using Bouduin.Util.Holiday.TestProgram.ViewModels.LocationTree;

namespace Bouduin.Util.Holiday.TestProgram.Views
{
    /// <summary>
    /// Interaction logic for LocationTreeView.xaml
    /// </summary>
    internal partial class LocationTreeView
    {
        #region constructor ---------------------------------------------------
        internal LocationTreeView()
        {
            InitializeComponent();
        }

        internal LocationTreeView(ILocationTreeViewModel locationTreeViewModel)
        {
            InitializeComponent();
            DataContext = locationTreeViewModel;
        }
        #endregion



    }
}
