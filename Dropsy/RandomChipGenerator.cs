using System;

namespace Dropsy
{
    public class RandomChipGenerator : IChipGenerator
    {
        private readonly Random _random = new Random();
        private readonly int _size;

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