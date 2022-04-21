using System.Collections.Generic;

namespace ClassLibraryModels
{
    public interface IRainMeasurementCollection
    {
        IEnumerable<RainMeasurement> Measurements { get; }

        void AddMeasurement();
    }
}