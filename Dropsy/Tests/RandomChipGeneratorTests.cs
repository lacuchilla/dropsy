using NUnit.Framework;

namespace Dropsy.Tests
{
    [TestFixture]
    class RandomChipGeneratorTests
    {
        [Test]
        public void NextReturnsRandomInRange()
        {
            var testObj = new RandomChipGenerator(5);
            Assert.LessOrEqual(1, testObj.Next());
            Assert.GreaterOrEqual(5, testObj.Next());
            var startingValue = testObj.Next();
            var tryCount = 0;
            while (tryCount < 10 && startingValue == testObj.Next())
                tryCount++;
            if (tryCount >= 10)
                Assert.Fail("Tried 10 times to get a different value and it didn't happen");
        }
    }
}
