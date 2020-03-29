using System;
using System.Collections.Generic;
using Demo.GeometryLib.Common;
using Demo.GeometryLib.Geometry;

namespace Demo.GeometryLib
{
    /// <summary>
    /// Helper class to create some predefined Geometry types. Can be used when creating new figures with existing Geometry type.
    /// </summary>
    public class GeometryBuilder
    {
        public IGeometry BuildPoly(IEnumerable<Point> points)
        {
            return new PolygonGeometry(points);
        }

        public IGeometry BuildTriangleByPoints(Point a, Point b, Point c)
        {
            return new TriangleGeometry(a,b,c);
        }

        public IGeometry BuildTriangleBySides(double a, double b, double c)
        {
            if (a.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(a), a, ErrorMessages.ErrorSideNegativeOrZero);
            if (b.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(b), b, ErrorMessages.ErrorSideNegativeOrZero);
            if (c.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(c), c, ErrorMessages.ErrorSideNegativeOrZero);
            return new TriangleGeometry(a,b,c);
        }

        public IGeometry BuildEllipseByRadius(double r1, double r2)
        {
            if (r1.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(r1), r1, ErrorMessages.ErrorRadiusNegativeOrZero);
            if (r2.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(r2), r2, ErrorMessages.ErrorRadiusNegativeOrZero);
            return new EllipseGeometry(Math.Max(r1,r2), Math.Min(r1,r2));
        }

        public IGeometry BuildEllipse(Point center, Point bigRadiusPoint, Point smallRadiusPoint)
        {
            return new EllipseGeometry(center, bigRadiusPoint, smallRadiusPoint);
        }

        public IGeometry BuildCircleByRadius(double r)
        {
            if (r.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(r), r, ErrorMessages.ErrorRadiusNegativeOrZero);
            return new EllipseGeometry(r,r);
        }

        public IGeometry BuildRectangleBySides(double a, double b)
        {
            if(a.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(a), a, ErrorMessages.ErrorSideNegativeOrZero);
            if(b.IsNegativeOrZero())
                throw new ArgumentOutOfRangeException(nameof(b), b, ErrorMessages.ErrorSideNegativeOrZero);
            return new PolygonGeometry(new Point[] {(0,0), (0,a), (b,a), (b,0)});
        }
    }
}