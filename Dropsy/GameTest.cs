using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void Construction()
        {
            var testObj = new Game(1);
            Assert.That(testObj, Is.Not.Null);
        }

        [Test]
        public void PlayDrawsAOneByOne()
        {
            var testObj = new Game(1);
            var screen = new FakeScreen();
            testObj.Screen = screen;
            testObj.Play();
            Assert.That(screen.Output, Is.EqualTo(
                "┌───┐\n" +
                "│   │\n" +
                "└───┘\n" +
                "  1  \n"));
        }

        [Test]
        public void PlayDrawsATwoByTwo()
        {
            var testObj = new Game(2);
            var screen = new FakeScreen();
            testObj.Screen = screen;
            testObj.Play();
            Assert.That(screen.Output, Is.EqualTo(
                "┌──────┐\n" +
                "│      │\n" +
                "│      │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }
    }

    public class FakeScreen : IScreen
    {
        public string Output = "";

        public void WriteLine(string line)
        {
            Output += line + "\n";
        }
    }
}