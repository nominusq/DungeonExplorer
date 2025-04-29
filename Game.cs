using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Manages the main gameplay loop.
    /// </summary>
    public class Game
    {
        private Player player;
        private GameMap map;
        private Room currentRoom;
        private bool isRunning;

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Welcome to the Dungeon Explorer!");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName);
            map = new GameMap();
            InitializeRooms();
            currentRoom = map.GetRooms().First();
            isRunning = true;

            GameLoop();
        }

        /// <summary>
        /// The main game loop.
        /// </summary>
        private void GameLoop()
        {
            while (isRunning)
            {
                Console.WriteLine("\n" + currentRoom.GetDescription());
                if (currentRoom.Monster != null && currentRoom.Monster.Health > 0)
                {
                    Console.WriteLine($"A {currentRoom.Monster.Name} is here! It looks hostile.");
                }
                if (currentRoom.Item != null)
                {
                    Console.WriteLine($"You see a {currentRoom.Item.Name} on the ground.");
                }
                Console.WriteLine($"Your Health: {player.Health} | Attack: {player.AttackPower} | Inventory: {player.Inventory.InventoryContents()}");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[N]orth, [S]outh, [E]ast, [W]est, [P]ick up item, [U]se item, [A]ttack monster, [Q]uit");

                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "n":
                        Move(currentRoom.North);
                        break;
                    case "s":
                        Move(currentRoom.South);
                        break;
                    case "e":
                        Move(currentRoom.East);
                        break;
                    case "w":
                        Move(currentRoom.West);
                        break;
                    case "p":
                        PickUpItem();
                        break;
                    case "u":
                        UseItem();
                        break;
                    case "a":
                        AttackMonster();
                        break;
                    case "q":
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        /// <summary>
        /// Moves the player to the next room if possible.
        /// </summary>
        /// <param name="nextRoom">The next room.</param>
        private void Move(Room nextRoom)
        {
            if (currentRoom.Monster != null && currentRoom.Monster.Health > 0)
            {
                Console.WriteLine($"You cannot flee! Defeat the {currentRoom.Monster.Name} first!");
                return;
            }

            if (nextRoom != null)
            {
                currentRoom = nextRoom;
            }
            else
            {
                Console.WriteLine("You cannot move in that direction.");
            }
        }

        /// <summary>
        /// Picks up the item in the current room.
        /// </summary>
        private void PickUpItem()
        {
            if (currentRoom.Item != null)
            {
                player.Inventory.Add(currentRoom.Item);
                Console.WriteLine($"You picked up a {currentRoom.Item.Name}!");
                currentRoom.Item = null;
            }
            else
            {
                Console.WriteLine("There is nothing to pick up.");
            }
        }

        /// <summary>
        /// Lets the player use an item from their inventory.
        /// </summary>
        private void UseItem()
        {
            Console.WriteLine("Enter the name of the item you want to use:");
            string itemName = Console.ReadLine();
            player.Inventory.UseItem(itemName, player);
        }

        /// <summary>
        /// Attacks the monster in the current room.
        /// </summary>
        private void AttackMonster()
        {
            if (currentRoom.Monster != null && currentRoom.Monster.Health > 0)
            {
                player.Attack(currentRoom.Monster);
                if (currentRoom.Monster.Health <= 0)
                {
                    Console.WriteLine($"You defeated the {currentRoom.Monster.Name}!");
                    currentRoom.Monster = null;
                }
                else
                {
                    currentRoom.Monster.Attack(player);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You have been slain...");
                        isRunning = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no monster here.");
            }
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        private void Quit()
        {
            Console.WriteLine("Thank you for playing Dungeon Explorer!");
            isRunning = false;
        }

        /// <summary>
        /// Initializes the rooms and their connections.
        /// </summary>
        private void InitializeRooms()
        {
            Room room1 = new Room("You are in a damp cave.");
            Room room2 = new Room("You are in a dark hallway.");
            Room room3 = new Room("You are in a small chamber with flickering torches.");
            Room room4 = new Room("You are in a room filled with bones.");
            Room room5 = new Room("You are in a mossy stone corridor.");

            room1.East = room2;
            room2.West = room1;
            room2.South = room3;
            room3.North = room2;
            room3.East = room4;
            room4.West = room3;
            room4.South = room5;
            room5.North = room4;

            room2.Monster = new Monster("Goblin", 30, 5);
            room3.Item = new Potion("Healing Potion", 20);
            room4.Monster = new Monster("Skeleton", 40, 7);
            room5.Item = new Weapon("Rusty Sword", 5);

            map.AddRoom(room1);
            map.AddRoom(room2);
            map.AddRoom(room3);
            map.AddRoom(room4);
            map.AddRoom(room5);
        }
    }
}
