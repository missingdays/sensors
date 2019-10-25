using System.Collections.Generic;
using System.Numerics;

namespace Sensors.calibration
{
    public class LinearCalibration : ICalibration
    {
        public ISingleSensorStrategy Calibrate(List<double>[] points)
        {
            LinearRegression regression = new LinearRegression(points[0], points[1]);
            ICoefficients coefficients = regression.GetCoefficients();
            return new LinearSingleSensorStrategy(coefficients.GetA(), coefficients.GetB());
        }
    }
}