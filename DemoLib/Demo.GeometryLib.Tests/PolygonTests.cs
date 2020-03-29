using Demo.GeometryLib.Common;
using NUnit.Framework;

namespace Demo.GeometryLib.Tests
{
    [TestFixture]
    public class PolygonTests
    {
        private GeometryBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new GeometryBuilder();
        }

        [Test]
        public void TestPolySquare()
        {
            IGeometry g = builder.BuildPoly(new Point[] { (0, 0), (0, 20), (10, 20), (10, 0) });
            Assert.AreEqual(g.Square(), 200);
        }
    }
}