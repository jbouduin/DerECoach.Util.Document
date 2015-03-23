using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Bouduin.Lib.Holidays;
using Bouduin.Lib.Holidays.Extensions;
using Bouduin.Lib.Holidays.Interface;
using Bouduin.Lib.Holidays.Locations;

namespace Bouduin.Holiday.ViewModels.HolidayGrid
{
    internal interface IHolidayGridViewModel
    {
        ILocation CurrentLocation { get; set; }
        ObservableCollection<IHolidayDate> CurrentHolidays { get; }
    }

    internal class HolidayGridViewModel: IHolidayGridViewModel, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged members --------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region IHolidayGridViewModel members ---------------------------------

        private ILocation _currentLocation;
        public ILocation CurrentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value; 
                this.TriggerNotification(PropertyChanged, () => CurrentLocation);
                LoadHolidays();
                //this.TriggerNotification(PropertyChanged, () => CurrentHolidays);
            }
        }

        private ObservableCollection<IHolidayDate> _currentHolidays = new ObservableCollection<IHolidayDate>();

        public ObservableCollection<IHolidayDate> CurrentHolidays
        {
            get { return _currentHolidays; }
            set
            {
                _currentHolidays = value;
                this.TriggerNotification(PropertyChanged, () => CurrentHolidays);
            }
        }
        #endregion

        #region private methods -----------------------------------------------

        private void LoadHolidays()
        {
            var serviceResult = Service.GetHolidayService().GetHolidayDates(CurrentLocation.Path);

            _currentHolidays.Clear();
            serviceResult.OrderBy(ob => ob.Date).ToList().ForEach(_currentHolidays.Add);


        }

        #endregion


    }
}
