using System;

namespace ClassLibraryModels
{
    ///public record RainMeasurement(Double Depth, DateTime Period);
    public class RainMeasurement
    {
        private Double _depth;
        private DateTime _period;

        public RainMeasurement(Double depth, DateTime period) 
        {
            _depth = depth;
            _period = period;
        }

        public override string ToString()
        {
            return $"depth = {_depth} and datetime = {_period}";
        }
    }
}
