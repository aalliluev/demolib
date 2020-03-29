using Demo.GeometryLib.Shapes;

namespace Demo.GeometryLib
{
    public interface IGeometryFacade
    {
        double GetTriangleSquare(double a, double b, double c);
        double GetCircleSquare(double radius);
        bool GetIsRightAngleTriangle(double a, double b, double c);
        double GetSquare(IShape shape);
    }
}