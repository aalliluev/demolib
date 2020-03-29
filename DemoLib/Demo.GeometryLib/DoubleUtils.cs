using System;
using System.Linq;

namespace Demo.GeometryLib
{
    public static class DoubleUtils
    {
        /// <summary>
        /// Determines if current double equals to Zero.
        /// </summary>
        /// <param name="d">Testing double.</param>
        /// <returns>True if Zero.</returns>
        public static bool IsZero(this double d)
        {
            return Math.Abs(d) < double.Epsilon;
        }

        /// <summary>
        /// Determines if the given double is a negative or zero.
        /// </summary>
        /// <param name="d">Testing double.</param>
        /// <returns>True if negative or Zero.</returns>
        public static bool IsNegativeOrZero(this double d)
        {
            return d <= 0 || IsZero(d);
        }

        /// <summary>
        /// Determines if two given doubles are equal to each other.
        /// </summary>
        /// <param name="d">First.</param>
        /// <param name="other">Second.</param>
        /// <returns>True if equals.</returns>
        public static bool CloseToEqual(this double d, double other)
        {
            return IsZero(d - other);
        }

        /// <summary>
        /// Determines if all given doubles are equal to a given testing double.
        /// </summary>
        /// <param name="d">Testing double to check against.</param>
        /// <param name="others">Set of testing doubles to check.</param>
        /// <returns>True if all others are equal to given testing double.</returns>
        public static bool CloseToEqual(this double d, params double[] others)
        {
            return others.All(other => CloseToEqual(d, other));
        }

        /// <summary>
        /// Determines if all given doubles are equal to each other.
        /// </summary>
        /// <param name="d">Testing double to check against.</param>
        /// <param name="others">Set of testing doubles to check.</param>
        /// <returns>True if all others are equal to given testing double.</returns>
        public static bool CloseToEqual(params double[] others)
        {
            return others.All(other => other.CloseToEqual(other));
        }

        /// <summary>
        /// Max Precision to return Squares, Angles, Perimeters .....
        /// </summary>
        public const int MaxPrecision = 9;
    }
}