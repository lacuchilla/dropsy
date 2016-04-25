using System;

namespace Dropsy
{
    public class ConsoleScreen : IScreen
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}