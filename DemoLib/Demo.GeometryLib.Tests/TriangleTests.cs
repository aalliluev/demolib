using System;
using Demo.GeometryLib.Common;
using Demo.GeometryLib.Geometry;
using NUnit.Framework;

namespace Demo.GeometryLib.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        private GeometryBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new GeometryBuilder();
        }

        [Test]
        public void PointsOnSameLineTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=>builder.BuildTriangleByPoints((1, 1), (2, 2), (3, 3)));
        }

        [TestCase(3,4,5,6)]
        public void TestTriangleSquare(double a, double b, double c, double testSquare)
        {
            TriangleGeometry t = (TriangleGeometry)builder.BuildTriangleBySides(a,b,c);
            var square = t.Square();
            var isRightAngle = t.IsRightAngle();

            Assert.AreEqual(square, testSquare);
            Assert.AreEqual(isRightAngle, true);
        }
    }
}