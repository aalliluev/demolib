using System;

namespace Demo.GeometryLib.Common
{
    /// <summary>
    /// Represents common 2D Vector.
    /// </summary>
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns True if both vectors have the same Angle.
        /// </summary>
        /// <param name="v">Second Vector.</param>
        /// <returns>True if both have same angles.</returns>
        public bool SameAngle(Vector v)
        {
            return (v.Y / v.X).CloseToEqual(Y / X);
        }

        /// <summary>
        /// Length of this Vector.
        /// </summary>
        public double Length => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));

        /// <summary>
        /// Angle of this vector in radians.
        /// </summary>
        public double Angle => Math.Acos(X / Length);

        /// <summary>
        /// Angle of this Vector in degrees.
        /// </summary>
        public double AngleInDegrees => Angle * 180 / Math.PI;
    }
}