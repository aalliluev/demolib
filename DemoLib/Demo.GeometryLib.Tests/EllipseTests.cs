using System;
using NUnit.Framework;

namespace Demo.GeometryLib.Tests
{
    [TestFixture]
    public class EllipseTests
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
            Assert.Throws<ArgumentOutOfRangeException>(() => builder.BuildEllipseByRadius(a, b));
        }

        [TestCase(1d, 1.5d)]
        [TestCase(1.5d, 5d)]
        public void InitDoesNotThrowTest(double a, double b)
        {
            Assert.DoesNotThrow(() => builder.BuildEllipseByRadius(a, b));
        }

        [Test]
        public void InitByPointAndRadiusDoesNotThrowTest()
        {
            Assert.DoesNotThrow(() => builder.BuildEllipse((-5, 0), (0, 0), (-5, 2)));
        }

        [TestCase(1.5, 3.7, 17.435839227423354d)]
        public void SquareTest(double a, double b, double square)
        {
            Assert.True((builder.BuildEllipseByRadius(a, b).Square() - square).CloseToEqual());
        }
    }
}