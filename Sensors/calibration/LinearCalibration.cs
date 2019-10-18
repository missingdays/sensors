using System.Collections.Generic;

namespace Sensors.calibration
{
    public class LinearCalibration : ICalibration
    {
        public ISingleSensorStrategy calibrate(List<IPoint> points)
        {
            LinearRegression regression = new LinearRegression(points);
            ICoefficients coefficients = regression.getCoefficients();
            return new LinearSingleSensorStrategy(coefficients.getA(), coefficients.getB());
        }
    }
}