using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Sensors.calibration
{
    public class LinearRegression
    {
        private List<double> _x;
        private List<double> _y;
        
        public LinearRegression(List<double> x, List<double> y)
        {
            _x = x;
            _y = y;
        }

        public ICoefficients GetCoefficients()
        {
            double[] xVals = _x.ToArray();
            double[] yVals = _y.ToArray();
            
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            double yIntercept = meanY - ((sCo / ssX) * meanX);
            double slope = sCo / ssX;
            
            return new Coefficients(slope, yIntercept);
        }
    }

    class Coefficients : ICoefficients
    {
        private double _a;
        private double _b;
        public Coefficients(double a, double b)
        {
            _a = a;
            _b = b;
        }


        public double GetA()
        {
            return _a;
        }

        public double GetB()
        {
            return _b;
        }
    }

    public interface ICoefficients
    {
        double GetA();
        double GetB();
    }
}