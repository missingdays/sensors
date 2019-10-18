using System.Threading;

namespace Sensors
{
    public class SimpleSingleSensor : ISingleSensor
    {
        private ISingleSensorStrategy _strategy;
        private ISensorInput _input;

        public SimpleSingleSensor(ISingleSensorStrategy strategy, ISensorInput input)
        {
            _strategy = strategy;
            _input = input;
        }

        public SimpleSingleSensor SetStrategy(ISingleSensorStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public SimpleSingleSensor SetInput(ISensorInput input)
        {
            _input = input;
            return this;
        }
        
        public double GetValue()
        {
            return _strategy.Compute(_input.GetValue());
        }
    }
}