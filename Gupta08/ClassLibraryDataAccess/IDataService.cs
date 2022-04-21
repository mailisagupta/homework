using ClassLibraryModels;
using System.Collections.Generic;

namespace ClassLibraryDataAccess
{
    public interface IDataService
    {
        void AddMeasurement();
        IEnumerable<RainMeasurement> ReturnMeasurement();
        //string ReturnMeasurement();
    }
}