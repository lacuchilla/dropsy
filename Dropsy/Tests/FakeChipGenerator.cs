namespace Dropsy.Tests
{
    public class FakeChipGenerator : IChipGenerator
    {
        public int NextDrop { get; set; }

        public int Next()
        {
            return NextDrop;
        }
    }
}