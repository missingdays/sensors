namespace Sensors
{
    public class LinearSingleSensorStrategy : ISingleSensorStrategy
    {
        private readonly double _a;
        private readonly double _b;

        public LinearSingleSensorStrategy(double a, double b)
        {
            _a = a;
            _b = b;
        }


        public double Compute(double input)
        {
            return _a * input + _b;
        }
    }
}