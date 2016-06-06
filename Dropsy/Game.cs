using System;

namespace Dropsy
{
    public class Game
    {
        private readonly int _size;
        private readonly string _middleConnector;
        private string _board;
        private string _nextChip;
        private int _columnIndex;
        private string _droppedChip;

        public Game(int size)
        {
            _size = size;
            Screen = new ConsoleScreen();
            ChipGenerator = new RandomChipGenerator(_size);
            _middleConnector = Repeat("───");
            _board = " ";
            _columnIndex = 0;
            _droppedChip = "";
        }

        public IScreen Screen { get; set; }
        public IChipGenerator ChipGenerator { get; set; }

        public void Play()
        {
            SetNextChipToDrop();
            DrawBoard();
            DropChipIntoColumn(Screen.ReadKey());
            DrawBoard();
        }

        public void SetNextChipToDrop()
        {
            _nextChip = ChipGenerator.Next().ToString();
        }

        public void DropChipIntoColumn(int column)
        {
            _droppedChip = _nextChip;
            _columnIndex = column;
            _nextChip = " ";
            _board = "1";
            
        }

        public void DrawBoard()
        {
            Screen.Clear();
            DrawChipToDrop();
            TopBorder();
            Field();
            BottomBorder();
            ColumnLabels();
        }

        private void DrawChipToDrop()
        {
            Screen.WriteLine(new string(' ', 3 *_size / 2 + 1) + _nextChip);
        }

        private void ColumnLabels()
        {
            var columnLabels = " ";
            for (int i = 1; i <= _size; i++)
                columnLabels += $" {i} ";
            columnLabels += " ";
            Screen.WriteLine(columnLabels);
        }

        private void BottomBorder()
        {
            Screen.WriteLine("└" + _middleConnector + "┘");
        }

        private void Field()
        {
            for (int row = 1; row <= _size; row++)
                Screen.WriteLine("│" + CreateRow(row) + "│");

        }

        private string CreateRow(int row)
        {
            if(row < _size)
                return new string(' ', 3 * _size);
           //new string('4', 1 * _size);
            var columnSpace = "";
            for (int column = 1; column <= _size; column++)
                if (column == _columnIndex)
                    columnSpace += $" {_droppedChip} ";
                else
                {
                    columnSpace += "   ";
                }
            return columnSpace;
        }

        private void TopBorder()
        {
            Screen.WriteLine("┌" + _middleConnector + "┐");
        }

        private string Repeat(string s)
        {
            var output = "";
            for (int i = 0; i < _size; i++)
                output += s;
            return output;
        }
    }
}