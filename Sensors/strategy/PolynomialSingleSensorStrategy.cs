namespace Sensors
{
    public class PolynomialSingleSensorStrategy : ISingleSensorStrategy
    {
        private double[] _coefficients;

        public PolynomialSingleSensorStrategy(double[] coefficients)
        {
            _coefficients = coefficients;
        }

        public PolynomialSingleSensorStrategy SetCoefficients(double[] coefficients)
        {
            _coefficients = coefficients;
            return this;
        }

        public double Compute(double input)
        {
            double result = 0;

            for (var i = _coefficients.Length - 1; i >= 0; i--)
            {
                result *= input;
                result += _coefficients[i];
            }

            return result;
        }
    }
}