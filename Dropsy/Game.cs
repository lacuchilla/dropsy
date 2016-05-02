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
            _middleConnector = Repeat("───");
        }

        public IScreen Screen { get; set; }

        public void Play()
        {
            TopBoarder();
            Field();
            BottomBoarder();
            ColumnLabels();
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