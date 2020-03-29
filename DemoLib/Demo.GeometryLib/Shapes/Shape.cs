using Demo.GeometryLib.Common;

namespace Demo.GeometryLib.Shapes
{
    /// <summary>
    /// Represents a drawable Shape which holds a Geometry and may hold things like colors for Pen and Fill, etc..
    /// </summary>
    public class Shape : IShape
    {
        public IGeometry Geometry { get; }

        public Shape(IGeometry geometry)
        {
            Geometry = geometry;
        }
    }
}