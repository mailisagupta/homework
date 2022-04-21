using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class RainMeasurementCollection : IRainMeasurementCollection
    {
        private Func<IEnumerable<RainMeasurement>> measurementsFunc;
        private IEventAggregator eventAggregator;

        public RainMeasurementCollection(Func<IEnumerable<RainMeasurement>> mf,
            IEventAggregator ea)
        {
            measurementsFunc = mf;
            eventAggregator = ea;
        }

        public IEnumerable<RainMeasurement> Measurements
        {
            get
            {
                List<RainMeasurement> a = new();
                foreach (RainMeasurement measurement in measurementsFunc())
                {
                    a.Add(measurement);
                }
                return a;
            }
        }

        public void AddMeasurement()
        {
            eventAggregator.GetEvent<EventClass>().Publish();
        }

        
    }
}
