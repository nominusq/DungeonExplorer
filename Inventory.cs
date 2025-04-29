using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player's inventory.
    /// </summary>
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void Add(Item item)
        {
            if (item != null)
            {
                items.Add(item);
            }
        }

        public void UseItem(string itemName, Player player)
        {
            Item item = items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                item.Use(player);
                items.Remove(item);
            }
            else
            {
                System.Console.WriteLine("Item not found.");
            }
        }

        public string InventoryContents()
        {
            return items.Any() ? string.Join(", ", items.Select(i => i.Name)) : "Empty";
        }
    }
}
