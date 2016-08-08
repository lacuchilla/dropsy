using System.Collections.Generic;
using NUnit.Framework;

namespace Dropsy.Tests
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
            _fakeChipToDrop = new FakeChipGenerator {NextDrop = 2};
            _testObj.ChipGenerator = _fakeChipToDrop;
        }

        [Test]
        public void AddsBlocksAfterFiveTurns()
        {
            var testObj = new Game(3, 6);
            var queuedChipGenerator = new QueuedChipGenerator();
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(6);
            testObj.ChipGenerator = queuedChipGenerator;
            var screen = new FakeScreen();
            testObj.Screen = screen;
            screen.QueueNextKeys(new List<int> {1, 2, 3, 1, 2});
            testObj.Play();
            Assert.That(screen.LastOutput, Is.EqualTo(
                "     6\n" +
                "┌─────────┐\n" +
                "│ 5  6    │\n" +
                "│ 5  5  6 │\n" +
                "│ █  █  █ │\n" +
                "└─────────┘\n" +
                "  1  2  3  \n"
                ));
        }

        [Test]
        public void ColumnOverflowingEndsGame()
        {
            var testObj = new Game(3, 6);
            var queuedChipGenerator = new QueuedChipGenerator();
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            queuedChipGenerator.Queue.Enqueue(5);
            testObj.ChipGenerator = queuedChipGenerator;
            var screen = new FakeScreen();
            testObj.Screen = screen;
            screen.QueueNextKeys(new List<int> {1, 1, 1, 2, 2, 3});
            testObj.Play();
            Assert.That(screen.LastOutput, Is.EqualTo(
                "      \n" +
                "┌─────────┐\n" +
                "│ 5  5    │\n" +
                "│ 5  5    │\n" +
                "│ █  █  █ │\n" +
                "└─────────┘\n" +
                "  1  2  3  \n"
                ));
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
            Assert.That(_screen.LastOutput, Is.EqualTo(
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
            Assert.That(_screen.LastOutput, Is.EqualTo(
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

            Assert.That(_screen.LastOutput, Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│    2 │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }

        [Test]
        public void DroppingAOnePopsItRightAway()
        {
            var testObj = new Game(2, 1);
            var queuedChipGenerator = new QueuedChipGenerator();
            queuedChipGenerator.Queue.Enqueue(1);
            queuedChipGenerator.Queue.Enqueue(1);
            testObj.ChipGenerator = queuedChipGenerator;
            var screen = new FakeScreen();
            testObj.Screen = screen;
            screen.SetNextkey(1);
            testObj.Play();
            var last = screen.Outputs.Count - 1;
            Assert.That(screen.Outputs[last - 2], Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│ 1    │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
            Assert.That(screen.Outputs[last - 1], Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│ *    │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
            Assert.That(screen.Outputs[last], Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│      │\n" +
                "│      │\n" +
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
            Assert.That(_screen.LastOutput, Is.EqualTo(
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

            Assert.That(_screen.LastOutput, Is.EqualTo(
                "     \n" +
                "┌──────┐\n" +
                "│    1 │\n" +
                "│    2 │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }

        [Test]
        public void PlayDoesntTakeNewChipsForFullColumn()
        {
            var testObj = new Game(2, 3);
            var queuedChipGenerator = new QueuedChipGenerator();
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(6);
            queuedChipGenerator.Queue.Enqueue(6);
            testObj.ChipGenerator = queuedChipGenerator;
            var screen = new FakeScreen();
            testObj.Screen = screen;
            screen.SetNextkey(1);
            testObj.Play();

            Assert.That(screen.LastOutput, Is.EqualTo(
                "    6\n" +
                "┌──────┐\n" +
                "│ 6    │\n" +
                "│ 6    │\n" +
                "└──────┘\n" +
                "  1  2  \n"
                ));
        }
    }
}