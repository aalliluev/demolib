using Demo.GeometryLib.Common;

namespace Demo.GeometryLib.Geometry
{
    public class CircleGeometry : EllipseGeometry
    {
        public CircleGeometry(Point center, Point radiusPoint) : base(center, radiusPoint, radiusPoint)
        {
        }

        public CircleGeometry(double radius) : base(radius, radius)
        {
        }
    }
}