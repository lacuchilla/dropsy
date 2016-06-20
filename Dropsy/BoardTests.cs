using NUnit.Framework;

namespace Dropsy
{
    [TestFixture]
    public class BoardTests
    {
        private Board _testObj;

        [SetUp]
        public void Setup()
        {
            _testObj= new Board(2);
        }

        [Test]
        public void Board_ReturnsAnEmptyBoard()
        {
            Assert.That( _testObj.GetCell(1, 1), Is.EqualTo(" "));
            Assert.That( _testObj.GetCell(2, 1), Is.EqualTo(" "));
        }

        [Test]
        public void PutAChipIn_GetAChipOutInSameLocation()
        {
            _testObj.AddToColumn(1, "5");
            Assert.That(_testObj.GetCell(1,1), Is.EqualTo("5"));
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
        public void AddingChipsToTwoColumns()
        {
            _testObj.AddToColumn(1, "1");
            _testObj.AddToColumn(2, "2");
            Assert.That(_testObj.GetCell(1, 1), Is.EqualTo("1"));
            Assert.That(_testObj.GetCell(2, 1), Is.EqualTo("2"));
        }

    }
}