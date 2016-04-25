using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void Construction()
        {
            var testObj = new Game();
            Assert.That(testObj, Is.Not.Null);
        }

        [Test]
        public void PlayShouldPlayTheGame()
        {
            var testObj = new Game();
            testObj.Play();
        }
    }
}