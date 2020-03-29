using System;
using Demo.GeometryLib.Common;
using NUnit.Framework;

namespace Demo.GeometryLib.Tests
{
    [TestFixture]
    public class RectangleTests
    {
        private GeometryBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new GeometryBuilder();
        }

        [TestCase(0d, 1.5d)]
        [TestCase(1.5d, 0d)]
        [TestCase(-0.5d, 1.5d)]
        [TestCase(0.5d, -1.5d)]
        [TestCase(-0.5d, -0d)]
        [TestCase(0.0d, 0d)]
        public void InitThrowsTest(double a, double b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>builder.BuildRectangleBySides(a, b));
        }

        [TestCase(double.Epsilon, 1.4d)]
        [TestCase(1.5d, double.Epsilon)]
        public void InitDoesNotThrowTest(double a, double b)
        {
            Assert.DoesNotThrow(() => builder.BuildRectangleBySides(a, b));
        }

        [TestCase(2, 3, 6)]
        [TestCase(2, 2, 4)]
        [TestCase(1.7, 3.8, 1.7 * 3.8)]
        public void SquareTest(double a, double b, double square)
        {
            Assert.True((builder.BuildRectangleBySides(a, b).Square() - square).IsZero());
        }
    }
}