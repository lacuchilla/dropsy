using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class GameTest
    {
        private Game _testObj;
        private FakeScreen _screen;
        private FakeChipGenerator _fakeChipToDrop;

        private void CreateTestObj(int size)
        {
            _testObj = new Game(size);
            _screen = new FakeScreen();
            _testObj.Screen = _screen;
            _fakeChipToDrop = new FakeChipGenerator();
            _fakeChipToDrop.NextDrop = 2;
            _testObj.ChipGenerator = _fakeChipToDrop;
        }

        [Test]
        public void Construction()
        {
            var testObj = new Game(1);
            Assert.That(testObj, Is.Not.Null);
        }


        [Test]
        public void DrawBoardDrawsANineByNineAndPutsChipInMiddleColumn()
        {
            CreateTestObj(9);
            _testObj.SetNextChipToDrop();
            _testObj.DrawBoard();
            Assert.That(_screen.Output, Is.EqualTo(
                "              2\n" +
                "┌───────────────────────────┐\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "│                           │\n" +
                "└───────────────────────────┘\n" +
                "  1  2  3  4  5  6  7  8  9  \n"
                ));
        }

        [Test]
        public void DrawBoardDrawsATwoByTwo()
        {
            CreateTestObj(2);
            _testObj.SetNextChipToDrop();

            _testObj.DrawBoard();
            Assert.That(_screen.Output, Is.EqualTo(
                "    2\n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│      │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }

        [Test]
        public void DropChipIntoColumnDropsChipToBottomOfSelectedColumn()
        {
            CreateTestObj(2);
            _testObj.SetNextChipToDrop();
            _testObj.DropChipIntoColumn(2);
            _testObj.DrawBoard();

            Assert.That(_screen.Output, Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│    2 │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }

        [Test]
        public void DropsMoreThanOneChip()
        {
            CreateTestObj(2);
            _testObj.SetNextChipToDrop();
            _testObj.DropChipIntoColumn(2);

            _testObj.DrawBoard();
            Assert.That(_screen.Output, Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│    2 │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));

            _fakeChipToDrop.NextDrop = 1;
            _testObj.SetNextChipToDrop();
            _testObj.DropChipIntoColumn(2);
            _testObj.DrawBoard();

            Assert.That(_screen.Output, Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│    1 │\n" +
                "│    2 │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }


        [Test]
        public void GameOver()
        {
        }

        [Test]
        public void PlayDrawsAOneByOne()
        {
            _testObj = new Game(1);
            _screen = new FakeScreen();
            _testObj.Screen = _screen;
            _screen.NextKey = 1;
            _testObj.Play();
            Assert.That(_screen.Output, Is.EqualTo(
                "   \n" +
                "┌───┐\n" +
                "│ 1 │\n" +
                "└───┘\n" +
                "  1  \n"));
        }

        [Test]
        public void PlayTakesANumberOfTurnsToPlay()
        {
            CreateTestObj(3);
            _screen.NextKey = 2;
            _testObj.Play(3);

            Assert.That(_screen.Output, Is.EqualTo(
                "      \n" +
                "┌─────────┐\n" +
                "│    2    │\n" +
                "│    2    │\n" +
                "│    2    │\n" +
                "└─────────┘\n" +
                "  1  2  3  \n"
                ));
        }
    }

    public class FakeChipGenerator : IChipGenerator
    {
        public int NextDrop { get; set; }

        public int Next()
        {
            return NextDrop;
        }
    }

    public class FakeScreen : IScreen
    {
        public string Output = "";
        public int NextKey { get; set; }

        public void WriteLine(string line)
        {
            Output += line + "\n";
        }

        public int ReadKey()
        {
            return NextKey;
        }

        public void Clear()
        {
            Output = "";
        }
    }
}