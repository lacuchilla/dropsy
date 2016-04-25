using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropsy
{
    public class Program
    {
        private const string UpperLeft = "┌";
        private const string UpperRight = "┐";
        private const string LowerLeft = "└";
        private const string LowerRight = "┘";
        private const string HorizontalBorder = "─";
        private const string VerticalBorder = "│";
        private const string EmptySpace = " ";
        private const string Block = "█";

        static void Main(string[] args)
        {
            var game = new Game(9);
            game.Play();
        }
    }
}
