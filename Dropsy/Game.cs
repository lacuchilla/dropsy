using System;

namespace Dropsy
{
    public class Game
    {
        private readonly int _size;
        private readonly string _middleConnector;

        public Game(int size)
        {
            _size = size;
            Screen = new ConsoleScreen();
            ChipGenerator = new RandomChipGenerator(_size);
            _middleConnector = Repeat("───");
        }

        public IScreen Screen { get; set; }
        public IChipGenerator ChipGenerator { get; set; }

        public void Play()
        {
            ChipToDrop();
            TopBoarder();
            Field();
            BottomBoarder();
            ColumnLabels();
        }

        private void ChipToDrop()
        {
            var nextChip = ChipGenerator.Next();
            Screen.WriteLine(new string(' ', 3 *_size / 2 + 1) + nextChip);
        }

        private void ColumnLabels()
        {
            var columnLabels = " ";
            for (int i = 1; i <= _size; i++)
                columnLabels += $" {i} ";
            columnLabels += " ";
            Screen.WriteLine(columnLabels);
        }

        private void BottomBoarder()
        {
            Screen.WriteLine("└" + _middleConnector + "┘");
        }

        private void Field()
        {
            for (int i = 0; i < _size; i++)
                Screen.WriteLine("│" + Repeat("   ") + "│");
        }

        private void TopBoarder()
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