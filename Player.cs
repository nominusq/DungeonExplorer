using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        // Adds an item to the inventory
        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
            }
        }

        // Returns a string of inventory contents
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
        }
    }
}