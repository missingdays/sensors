using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Sensors.calibration;

namespace Sensors
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IPoint> points = new List<IPoint>(new[]
            {
                new Point(0, 0),
                new Point(1, 2.3),
                new Point(2, 4.4),
                new Point(3, 6.1),
                new Point(2, 3.8),
                new Point(1, 1.8), 
            });
            
            ICalibration calibration = new LinearCalibration();
            ISingleSensorStrategy strategy = calibration.calibrate(points);
            ISingleSensor input = new ConstantSingleSensor(2);
            ISingleSensor sensor = new SimpleSingleSensor(strategy, input);
            
            Console.WriteLine(sensor.GetValue());
        }
   }
}