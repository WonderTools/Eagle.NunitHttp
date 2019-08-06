using NUnit.Framework;

namespace Eagle.SampleTests
{
    public class Tests  
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Test2(int x)
        {
            Assert.Pass();
        }
    }
}