using ClassLibraryModels;
using System;
using System.Collections.Generic;

namespace ClassLibraryDataAccess
{
    public class DataService : IDataService
    {

        private static DateTime _currentDateTime = DateTime.Now.AddDays(1);
        private List<RainMeasurement> _measurement =
            new List<RainMeasurement>
            {
                new RainMeasurement(1.9,_currentDateTime),
                new RainMeasurement(2.9,_currentDateTime.AddDays(2))
            };

        public IEnumerable<RainMeasurement> ReturnMeasurement()
        {
            return _measurement;
        }

        public void AddMeasurement()
        {
            Random random = new Random();
            _measurement.Add(new RainMeasurement(random.NextDouble(), DateTime.Now));
        }
    }
}
