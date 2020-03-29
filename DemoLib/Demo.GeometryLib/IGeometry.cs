namespace Demo.GeometryLib
{
    /// <summary>
    /// Basic contract of any 2D geometry.
    /// </summary>
    public interface IGeometry
    {
        /// <summary>
        /// Returns Square of a figure presented by current geometry.
        /// </summary>
        /// <returns>Square.</returns>
        double Square();
    }
}