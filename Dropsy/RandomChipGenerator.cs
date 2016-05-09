using System;

namespace Dropsy
{
    public class RandomChipGenerator : IChipGenerator
    {
        private int _size;
        private Random _random = new Random();

        public RandomChipGenerator(int size)
        {
            _size = size;
        }

        public int Next()
        {
            return _random.Next(_size) + 1;
        }
    }
}