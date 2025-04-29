using System;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Contains unit tests for the Dungeon Explorer game.
    /// </summary>
    public class GameTest
    {
        /// <summary>
        /// Runs basic tests on the Player, Room, Inventory, and Monster classes.
        /// </summary>
        public void RunTests()
        {
            // Test Player
            Player player = new Player("TestPlayer", 100);
            Debug.Assert(player.Name == "TestPlayer", "Player name not initialized correctly.");
            Debug.Assert(player.Health == 100, "Player health not initialized correctly.");

            // Test Inventory and Items
            Weapon sword = new Weapon("Sword", 20);
            Potion potion = new Potion("Health Potion", 30);
            player.Inventory.Add(sword);
            player.Inventory.Add(potion);

            Debug.Assert(player.Inventory.GetItems().Contains(sword), "Weapon not added to inventory.");
            Debug.Assert(player.Inventory.GetItems().Contains(potion), "Potion not added to inventory.");

            var weapons = player.Inventory.GetItems().OfType<Weapon>();
            Debug.Assert(weapons.Count() == 1, "Weapon filtering via LINQ failed.");
            Debug.Assert(weapons.First().Name == "Sword", "Weapon name mismatch after LINQ filtering.");

            // Test Monster
            Monster goblin = new Monster("Goblin", 40, 5);
            Debug.Assert(goblin.Name == "Goblin", "Monster name not initialized correctly.");
            Debug.Assert(goblin.Health == 40, "Monster health not initialized correctly.");
            Debug.Assert(goblin.AttackPower == 5, "Monster attack power not initialized correctly.");

            // Test damage
            player.TakeDamage(20);
            Debug.Assert(player.Health == 80, "Damage to player not applied correctly.");

            goblin.TakeDamage(15);
            Debug.Assert(goblin.Health == 25, "Damage to monster not applied correctly.");

            // Test Room and GameMap
            Room testRoom = new Room("Test Room");
            testRoom.Monster = goblin;

            Debug.Assert(testRoom.GetDescription() == "Test Room", "Room description not correct.");
            Debug.Assert(testRoom.Monster != null, "Room enemy not assigned properly.");

            GameMap map = new GameMap();
            Debug.Assert(map.GetRooms().Count() >= 1, "GameMap did not initialize rooms properly.");

            Console.WriteLine("All tests passed successfully!");
        }
    }
}
