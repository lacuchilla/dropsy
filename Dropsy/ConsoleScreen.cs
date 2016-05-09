using System;

namespace Dropsy
{
    public class ConsoleScreen : IScreen
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public int ReadKey()
        {
            return Console.ReadKey().KeyChar - '0';
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}