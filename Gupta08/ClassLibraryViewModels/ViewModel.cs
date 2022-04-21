using Prism.Events;
using ClassLibraryModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ClassLibraryViewModels
{
    public class ViewModel
    {
        private IDataProvider _dataProvider;
        private IEventAggregator _eventAggregator;

        public IRainMeasurementCollection RainM { get; }
        public ObservableCollection<RainMeasurement> RainMesure { get; set; }

        public ViewModel(IRainMeasurementCollection rainM, IDataProvider dataProvider, IEventAggregator eventAggregator)
        {
            _dataProvider = dataProvider;
            _eventAggregator = eventAggregator;
            RainM = rainM;
            RainMesure = new ObservableCollection<RainMeasurement>();
            UpdateRainMeasuremnet();

            _eventAggregator.GetEvent<EventClass>().Subscribe(OnAddMeasurement);

            AddMeasurementCommand = new DelegateCommand(() => OnAddMeasurement());
        }

        private void OnAddMeasurement()
        {
            _dataProvider.AddMeasurement();
            UpdateRainMeasuremnet();
        }

        private void UpdateRainMeasuremnet()
        {
            
            foreach (RainMeasurement measurement in RainM.Measurements)
            {
                RainMesure.Add(measurement);
            }
        }

        public ICommand AddMeasurementCommand { get; }

    }
}
