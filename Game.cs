using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        public Game()
        {
            // Initialise player and room
            player = new Player("Hero", 100);
            currentRoom = new Room("A dark and damp dungeon room with flickering torches.");

            // Display welcome message
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.WriteLine($"You are {player.Name} with {player.Health} health.");
            Console.WriteLine("Explore the dungeon and find the treasure!");
        }

        public void Start()
        {
            playing = true;

            while (playing)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Look around");
                Console.WriteLine("2. Check status");
                Console.WriteLine("3. Pick up an item");
                Console.WriteLine("4. Exit game");
                Console.Write("Choose an action: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine($"\n{currentRoom.GetDescription()}");
                        break;

                    case "2":
                        Console.WriteLine($"\nPlayer: {player.Name}");
                        Console.WriteLine($"Health: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;

                    case "3":
                        Console.Write("\nEnter item name: ");
                        string item = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            player.PickUpItem(item);
                            Console.WriteLine($"{item} added to your inventory.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid item name.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nExiting game...");
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid input. Try again.");
                        break;
                }
            }
        }
    }
}
