using ClassLibraryDataAccess;
using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryViewModels
{
    public class DataProvider : IDataProvider
    {
        private IDataService _dataService;

        public DataProvider(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IEnumerable<RainMeasurement> ReturnMeasurement()
        {
            return _dataService.ReturnMeasurement();
        }

        public void AddMeasurement()
        {
            _dataService.AddMeasurement();
        }
    }
}
