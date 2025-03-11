using System.Diagnostics;

namespace DungeonExplorer
{
    public class GameTest
    {
        public void RunTests()
        {
            Player player = new Player("TestPlayer", 100);
            Room room = new Room("Test Room");

            Debug.Assert(player.Name == "TestPlayer", "Player name not initialized correctly.");
            Debug.Assert(player.Health == 100, "Player health not initialized correctly.");
            Debug.Assert(room.GetDescription() == "Test Room", "Room description not initialized correctly.");

            player.PickUpItem("Sword");
            Debug.Assert(player.InventoryContents().Contains("Sword"), "Item not added to inventory correctly.");

            Console.WriteLine("All tests passed.");
        }
    }
}
