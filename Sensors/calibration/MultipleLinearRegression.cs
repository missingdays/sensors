
using Extreme.DataAnalysis;
using Extreme.Mathematics;
using Extreme.Mathematics.Algorithms;
using Extreme.Statistics;

namespace Sensors.calibration
{
    public class MultipleLinearRegression
    {
        private Vector<double>[] _x;
        private Vector<double> _y;

        public MultipleLinearRegression(Vector<double>[] x, Vector<double> y)
        {
            _x = x;
            _y = y;
        }


        public IMultipleCoefficients GetCoefficients()
        {
            var model = new LinearRegressionModel(_y, _x);
            model.Fit();

            return new MultipleCoefficients(model.ParameterValues);
        }
    }

    public interface IMultipleCoefficients
    {
        Vector<double> GetCoefficients();
    }

    class MultipleCoefficients : IMultipleCoefficients
    {
        private Vector<double> _parameters;

        public MultipleCoefficients(Vector<double> parameters)
        {
            _parameters = parameters;
        }

        public Vector<double> GetCoefficients()
        {
            return _parameters;
        }
    }
}