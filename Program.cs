using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Main entry point for the Dungeon Explorer game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point for the console application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            bool runTests = false; // Set to 'true' to test

            if (runTests)
            {
                GameTest tester = new GameTest();
                tester.RunTests();
                Console.WriteLine("\n--- Tests Completed Successfully ---\n");
            }

            Game game = new Game();
            game.Start();

            Console.WriteLine("\nGame Over. Thanks for playing!");
        }
    }
}
