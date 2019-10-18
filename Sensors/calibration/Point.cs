namespace Sensors.calibration
{
    public class Point : IPoint
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        
        public double getX()
        {
            return _x;
        }

        public double getY()
        {
            return _y;
        }
    }
}