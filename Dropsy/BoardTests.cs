using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class BoardTests
    {
        [SetUp]
        public void Setup()
        {
            _testObj = new Board(2);
        }

        private Board _testObj;

        private void AssertCellBlank(string result)
        {
            Assert.That(result, Is.EqualTo(" "));
        }

        [Test]
        public void AddingChipsToTwoColumns()
        {
            _testObj.AddToColumn(1, "1");
            _testObj.AddToColumn(2, "2");
            Assert.That(_testObj.GetCell(1, 1), Is.EqualTo("1"));
            Assert.That(_testObj.GetCell(2, 1), Is.EqualTo("2"));
        }

        [Test]
        public void Board_ReturnsAnEmptyBoard()
        {
            Assert.That(_testObj.GetCell(1, 1), Is.EqualTo(" "));
            Assert.That(_testObj.GetCell(2, 1), Is.EqualTo(" "));
        }

        [Test]
        public void ChipsStack()
        {
            _testObj.AddToColumn(1, "5");
            _testObj.AddToColumn(1, "3");
            Assert.That(_testObj.GetCell(1, 1), Is.EqualTo("5"));
            Assert.That(_testObj.GetCell(1, 2), Is.EqualTo("3"));
        }

        [Test]
        public void GetCell_ReturnBlankForColumnOutOfRange()
        {
            AssertCellBlank(_testObj.GetCell(3, 1));
        }

        [Test]
        public void GetCell_ReturnBlankForColumnOutOfRange_TooSmall()
        {
            AssertCellBlank(_testObj.GetCell(0, 1));
        }

        [Test]
        public void GetCell_ReturnsBlankForRowOutOfRange()
        {
            AssertCellBlank(_testObj.GetCell(1, 3));
        }

        [Test]
        public void GetCell_ReturnsBlankForRowOutOfRange_TooSmall()
        {
            AssertCellBlank(_testObj.GetCell(1, 0));
        }

        [Test]
        public void PutAChipIn_GetAChipOutInSameLocation()
        {
            _testObj.AddToColumn(1, "5");
            Assert.That(_testObj.GetCell(1, 1), Is.EqualTo("5"));
        }

        [Test]
        public void ColumnIsFull_ReturnsTrueWhenColumnMatchesSizeOfBoard()
        {
            _testObj.AddToColumn(1, "1");
            _testObj.AddToColumn(1, "1");
            Assert.That(_testObj.ColumnIsFull(1), Is.True);
        }

        [Test]
        public void ColumnIsFull_ReturnsFalseWhenColumnEmpty()
        {
            Assert.That(_testObj.ColumnIsFull(1), Is.False);
        }

        [Test]
        public void BoardIsFull_WhenAllColumnsAreFull()
        {
            _testObj.AddToColumn(1, "1");
            _testObj.AddToColumn(1, "1");
            _testObj.AddToColumn(2, "1");
            _testObj.AddToColumn(2, "1");
            Assert.That(_testObj.IsFull(), Is.True);
        }
    }
}