using System;
using System.Collections.Generic;
using System.Linq;
using Demo.GeometryLib.Common;

namespace Demo.GeometryLib.Geometry
{
    public class TriangleGeometry : PolygonGeometry
    {
        public TriangleGeometry(Point a, Point b, Point c) : base(TriangleGeometry.CheckPointsNotOnOneLine(new[] { a, b, c }))
        {
        }

        public TriangleGeometry(double a, double b, double c) : base(GetPointsFromSides(a, b, c))
        {
        }

        private static IEnumerable<Point> CheckPointsNotOnOneLine(Point[] points)
        {
            List<Vector> vectors = new List<Vector>();
            for (int i = 1; i < points.Length; i++)
            {
                vectors.Add(points[i] - points[i-1]);
            }
            vectors.Add(points[0] - points[points.Length-1]);

            bool haveSameAngle = DoubleUtils.CloseToEqual(vectors.Select(v => v.Angle).ToArray());

            if(haveSameAngle)
                throw new ArgumentOutOfRangeException(nameof(points), points, "All points are on the same line");
            return points;
        }

        private static IEnumerable<Point> GetPointsFromSides(double a, double b, double c)
        {
            if (a.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(a), a, ErrorMessages.ErrorSideNegativeOrZero);
            if (b.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(b), b, ErrorMessages.ErrorSideNegativeOrZero);
            if (c.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(c), c, ErrorMessages.ErrorSideNegativeOrZero);

            bool isCorrectTriangle = (a + b > c) && (a + c > b) && (b + c > a);
            if (!isCorrectTriangle)
                throw new ArgumentException(ErrorMessages.ErrorTriangleSidesRuleViolates);

            double[] sides = new[] { a, b, c };
            double maxSide = sides.Max(); // max side is needed to ensure I'm looking for other than the biggest angle in a triangle.
            double minSide = sides.Min();
            double lastSide = a + b + c - maxSide - minSide;
            
            // making 2 points from center of coordinate system.
            Point A = (0, 0);
            Point B = (maxSide, 0);
            // need to find roateAngle (any angle left, but not the biggest one, that's why I take angle against the 'lastSide' and not against the 'maxSide').
            double rotateAngle = Math.Acos((Math.Pow(minSide, 2) + Math.Pow(maxSide, 2) - Math.Pow(lastSide, 2)) / (2 * minSide * maxSide));
            double cosRotate = Math.Cos(rotateAngle);
            double sinRotate = Math.Sin(rotateAngle);
            // rotate vector {minSide,0} with rotateAngle found, using the rotation matrix to find the location of the thrid point.
            Point C = (Math.Round(minSide * cosRotate, DoubleUtils.MaxPrecision),
                       Math.Round(minSide * sinRotate, DoubleUtils.MaxPrecision));
            return new[] { A, B, C };
        }

        /// <summary>
        /// Specific to Triangle logic. Determines if this is a rightangle triangle.
        /// </summary>
        /// <returns>True if it is a rightangle triangle.</returns>
        public bool IsRightAngle()
        {
            // calculating sides from points.
            double a = (Points[1] - Points[0]).Length;
            double b = (Points[2] - Points[1]).Length;
            double c = (Points[0] - Points[2]).Length;

            if ((a-b).IsZero() && (b-c).IsZero())
                return false; // if all side equal to each other it is definitely not a rightangle triangle.

            double[] array = new[] { a, b, c }.OrderBy(i => i).ToArray(); // sorting to find out max side and others.
            var k1 = array[0];
            var k2 = array[1];
            var h = array[2];
            var squareDiff = Math.Sqrt(Math.Pow(k1, 2) + Math.Pow(k2, 2)) - Math.Sqrt(Math.Pow(h, 2));
            return squareDiff.IsZero();
        }
    }
}