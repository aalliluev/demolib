using Demo.GeometryLib.Common;

namespace Demo.GeometryLib.Geometry
{
    public class EllipseGeometry : IGeometry
    {
        private readonly Point center, bigRadiusPoint, smallRadiusPoint;

        public EllipseGeometry(Point center, Point bigRadiusPoint, Point smallRadiusPoint)
        {
            this.center = center;
            this.bigRadiusPoint = bigRadiusPoint;
            this.smallRadiusPoint = smallRadiusPoint;
            BigRadius = (bigRadiusPoint - center).Length;
            SmallRadius = (smallRadiusPoint - center).Length;
        }

        public EllipseGeometry(double bigRadius, double smallRadius)
        {
            center = (0,0);
            BigRadius = bigRadius;
            SmallRadius = smallRadius;
            bigRadiusPoint = (bigRadius, 0);
            smallRadiusPoint = (0, smallRadius);
        }

        public double BigRadius { get; private set; }
        public double SmallRadius { get; private set; }

        public Point Center => center;
        public Point BigRadiusPoint => bigRadiusPoint;
        public Point SmallRaduisPoint => smallRadiusPoint;
        public double Square()
        {
            // delegating call to some Math-related function holder for the sake of code-reuse.
            return MathFormulaLibrary.EllipseSquare(BigRadius, SmallRadius);
        }
    }
}