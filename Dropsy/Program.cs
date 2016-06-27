 /*
 * Stories:
 * 1. Build and display an empty 1x1 to 9x9 box
 * 2. column labels
 * 3. random drop chip at top center
 * 4. user picks which column the chip drops into
 *>5. drops stack, dropping into full column does nothing, & game ends when all columns full
 * 
 */

namespace Dropsy
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game(9);
            game.Play(25);
        }
    }
}