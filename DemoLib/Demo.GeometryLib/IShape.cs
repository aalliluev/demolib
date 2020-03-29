namespace Demo.GeometryLib
{
    /// <summary>
    /// Represents a drawable Shape which holds a Geometry and may hold things like colors for Pen and Fill, etc..
    /// </summary>
    public interface IShape
    {
        IGeometry Geometry { get; }
    }
}