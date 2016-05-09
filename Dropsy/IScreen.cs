namespace Dropsy
{
    public interface IScreen
    {
        void WriteLine(string line);
        int ReadKey();
        void Clear();
    }
}