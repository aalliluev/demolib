using System.Collections.Generic;
using Demo.GeometryLib.Common;

namespace Demo.GeometryLib.Geometry
{
    public class PolygonGeometry : IGeometry
    {
        private readonly List<Point> points;

        public PolygonGeometry(IEnumerable<Point> points)
        {
            this.points = new List<Point>(points);
        }

        public IReadOnlyList<Point> Points => points;
        public double Square()
        {
            // delegating call to some Math-related function holder for the sake of code-reuse.
            return MathFormulaLibrary.PolySquare(Points);
        }
    }
}