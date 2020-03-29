using System;

namespace Demo.GeometryLib.Common
{
    /// <summary>
    /// Represents 2D point.
    /// </summary>
    public struct Point
    {
        private readonly double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Usefull convertion from ValueTuple to allow expr like Point p = (5,4);
        /// </summary>
        /// <param name="xy">ValueTuple of a pair doubles</param>
        public static implicit operator Point(ValueTuple<double,double> xy)
        {
            return new Point(xy.Item1, xy.Item2);
        }

        /// <summary>
        /// Returns Vector as a result of subtraction of 2 points.
        /// </summary>
        /// <param name="p1">Point 1.</param>
        /// <param name="p2">Point 2.</param>
        /// <returns>Vector.</returns>
        public static Vector operator - (Point p1, Point p2)
        {
            return new Vector(p2.x-p1.x, p2.y- p1.y);
        }
        
        public double X => x;
        public double Y => y;
    }
}