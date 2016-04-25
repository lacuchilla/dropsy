using System;

namespace Dropsy
{
    public class Game
    {
        private readonly int _size;

        public Game(int size)
        {
            _size = size;
            Screen = new ConsoleScreen();
        }

        public IScreen Screen { get; set; }

        public void Play()
        {
            var middleConnector = Repeat("───");
            Screen.WriteLine("┌" + middleConnector + "┐");
            for (int i = 0; i < _size; i++)
                Screen.WriteLine("│" + Repeat("   ") + "│");
            Screen.WriteLine("└" + middleConnector + "┘");
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