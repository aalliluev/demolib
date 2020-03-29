using NUnit.Framework;

namespace Demo.GeometryLib.Tests
{
    [TestFixture]
    public class DoubleUtilsTest
    {
        [TestCase(0d)]
        [TestCase((double.Epsilon*2.5/2.5)-double.Epsilon)]
        public void Test(double d)
        {
            Assert.True(d.IsZero());
        }

        [TestCase(0, 0-0)]
        [TestCase(0, 0+0)]
        [TestCase(double.Epsilon, double.Epsilon)]
        public void TestEquality(double one, double another)
        {
            Assert.IsTrue(one.CloseToEqual(another));
        }
    }
}