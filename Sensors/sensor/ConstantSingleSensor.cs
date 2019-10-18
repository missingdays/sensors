namespace Sensors
{
    public class ConstantSingleSensor : ISingleSensor
    {
        private double _value;

        public ConstantSingleSensor(double value)
        {
            _value = value;
        }

        double ISensorInput.GetValue()
        {
            return _value;
        }
    }
}