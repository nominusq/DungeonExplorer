using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private bool playing;

        public Game()
        {
            player = new Player("Hero", 100);
            SetupRooms();
            Console.WriteLine("Welcome to Dungeon Explorer!");
        }

        private void SetupRooms()
        {
            // Create rooms
            Room room1 = new Room("A dark room with stone walls.");
            Room room2 = new Room("A narrow hallway with torches flickering.");
            Room room3 = new Room("A large hall with a skeleton on the floor.");
            Room room4 = new Room("A treasure room. You feel something watching you...");

            // Link rooms
            room1.East = room2;
            room2.West = room1;
            room2.East = room3;
            room3.West = room2;
            room3.South = room4;
            room4.North = room3;

            // Add enemies
            room2.Enemy = new Enemy("Goblin", 30, 5);
            room4.Enemy = new Enemy("Orc", 50, 10);

            currentRoom = room1;
        }

        public void Start()
        {
            playing = true;

            while (playing && player.Health > 0)
            {
                Console.WriteLine($"\n{currentRoom.GetDescription()}");
                if (currentRoom.Enemy != null)
                {
                    Console.WriteLine($"An enemy {currentRoom.Enemy.Name} is here!");
                }

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Attack enemy");
                Console.WriteLine("2. Move");
                Console.WriteLine("3. Check status");
                Console.WriteLine("4. Exit game");
                Console.Write("Choose an action: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (currentRoom.Enemy != null)
                        {
                            player.Attack(currentRoom.Enemy);
                            Console.WriteLine($"You hit the {currentRoom.Enemy.Name}!");

                            if (currentRoom.Enemy.Health <= 0)
                            {
                                Console.WriteLine($"You defeated the {currentRoom.Enemy.Name}!");
                                currentRoom.Enemy = null;
                            }
                            else
                            {
                                player.TakeDamage(currentRoom.Enemy.AttackPower);
                                Console.WriteLine($"The {currentRoom.Enemy.Name} hits you! Health = {player.Health}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No enemy here.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Move to (North, South, East, West)?");
                        string direction = Console.ReadLine()?.ToLower();
                        Move(direction);
                        break;

                    case "3":
                        Console.WriteLine($"Health: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;

                    case "4":
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

            if (player.Health <= 0)
            {
                Console.WriteLine("You have died! Game over.");
            }
        }

        private void Move(string direction)
        {
            Room nextRoom;
            switch (direction)
            {
                case "north":
                    nextRoom = currentRoom.North;
                    break;
                case "south":
                    nextRoom = currentRoom.South;
                    break;
                case "east":
                    nextRoom = currentRoom.East;
                    break;
                case "west":
                    nextRoom = currentRoom.West;
                    break;
                default:
                    nextRoom = null;
                    break;
            }

            if (nextRoom != null)
            {
                currentRoom = nextRoom;
            }
            else
            {
                Console.WriteLine("You can't go that way.");
            }
        }
    }
}
