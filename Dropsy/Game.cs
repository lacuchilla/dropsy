namespace Dropsy
{
    public class Game
    {
        public Game(int size)
        {
            Screen = new ConsoleScreen();
        }

        public IScreen Screen { get; set; }

        public void Play()
        {
            Screen.WriteLine("┌───┐");
            Screen.WriteLine("│   │");
            Screen.WriteLine("└───┘");
        }
    }
}