using System.Collections.Generic;

namespace Sensors.calibration
{
    public interface ICalibration
    {
        ISingleSensorStrategy calibrate(List<IPoint> points);
    }
}