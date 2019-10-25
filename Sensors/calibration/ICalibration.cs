using System.Collections.Generic;
using System.Numerics;

namespace Sensors.calibration
{
    public interface ICalibration
    {
        ISingleSensorStrategy Calibrate(List<double>[] points);
    }
}