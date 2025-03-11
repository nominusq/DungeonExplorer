using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameTest test = new GameTest();
            test.RunTests();

            Game game = new Game();
            game.Start();

            Console.WriteLine("\nGame Over. Thanks for playing!");
        }
    }
}
