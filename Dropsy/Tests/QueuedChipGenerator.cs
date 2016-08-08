using System.Collections.Generic;

namespace Dropsy.Tests
{
    public class QueuedChipGenerator : IChipGenerator
    {
        public Queue<int> Queue = new Queue<int>();

        public int Next()
        {
            return Queue.Dequeue();
        }
    }
}