using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.GeometryLib.Common
{
    /// <summary>
    /// Commmon repository of Math/Geometry functions that can be reused anywhere in calculation of geomtry charachteristics (squares, perimeters...).
    /// </summary>
    public static class MathFormulaLibrary
    {
        /// <summary>
        /// Gets common Ellipse square.
        /// </summary>
        /// <param name="radius1">Raduis 1</param>
        /// <param name="radius2">Radius 2</param>
        /// <returns>Square of an ellipse.</returns>
        public static double EllipseSquare(double radius1, double radius2)
        {
            return Math.Round(Math.PI * (radius1 * radius2), DoubleUtils.MaxPrecision);
        }

        /// <summary>
        /// Gaussian square for non-selfcrossing polygons described by a given set of points.
        /// </summary>
        /// <param name="points">Set of points.</param>
        /// <returns>Square of a polygon.</returns>
        public static double PolySquare(IEnumerable<Point> points)
        {
            // Gaussian algo for non-selfcrossing polygons.
            // here should be performed some checks on initial set of points (correct order, no selfcrossing...).
            var polygon = points.ToList();
            int pointCount = polygon.Count;
            double[,] matrix = new double[pointCount + 1,2];

            // all points into a matrix each point per row.
            for (int i = 0; i < pointCount; i++)
            {
                matrix[i, 0] = polygon[i].X;
                matrix[i, 1] = polygon[i].Y;
            }

            // adding start point also as the last one.
            matrix[pointCount, 0] = polygon[0].X;
            matrix[pointCount, 1] = polygon[0].Y;

            double xyMultiSum = 0d, yxMultiSum = 0d;
            // doing cross multiplication and sum.
            for (int i = 0; i < pointCount; i++)
            {
                xyMultiSum += matrix[i, 0] * matrix[i + 1, 1]; // [\] SUM(x(i) * y(i+1))
                yxMultiSum += matrix[i, 1] * matrix[i + 1, 0]; // [/] SUM(y(i) * x(i+1))
            }
            // square is a positive difference between sums divided by 2.
            return Math.Round(Math.Abs(xyMultiSum - yxMultiSum) / 2, DoubleUtils.MaxPrecision);
        }
    }
}