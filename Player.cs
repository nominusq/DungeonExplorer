using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player in the game.
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory;

        /// <summary>
        /// Creates a new player with the specified name and health.
        /// </summary>
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            inventory = new List<string>();
        }

        public void PickUpItem(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                inventory.Add(item);
            }
        }

        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
        }

        /// <summary>
        /// Reduces the player's health.
        /// </summary>
        /// <param name="damage">Amount of damage to apply.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        /// <summary>
        /// Attacks an enemy.
        /// </summary>
        /// <param name="enemy">The enemy to attack.</param>
        public void Attack(Enemy enemy)
        {
            enemy.Health -= 10;
        }
    }
}
