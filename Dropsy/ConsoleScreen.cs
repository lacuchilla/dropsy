using System;
using System.Threading;

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
            //need to handle case when user types something other than  1 - 9
            return Console.ReadKey().KeyChar - '0';
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Pause()
        {
            Thread.Sleep(500);
        }
    }
}