using ClassLibraryModels;
using System.Collections.Generic;

namespace ClassLibraryViewModels
{
    public interface IDataProvider
    {
        void AddMeasurement();
        IEnumerable<RainMeasurement> ReturnMeasurement();
        //string ReturnMeasurement();

    }
}