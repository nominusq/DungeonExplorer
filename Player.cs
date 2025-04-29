using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the player in the game.
    /// </summary>
    public class Player : Creature
    {
        public Inventory Inventory { get; private set; }

        /// <summary>
        /// Creates a new player with the specified name and health.
        /// </summary>
        public Player(string name, int health)
            : base(name, health, 10) // Default attack power 10
        {
            Inventory = new Inventory();
        }

        /// <summary>
        /// Boosts the player's attack power.
        /// </summary>
        /// <param name="amount">Amount to boost.</param>
        public void BoostAttack(int amount)
        {
            AttackPower += amount;
            Console.WriteLine($"{Name}'s attack increased by {amount}.");
        }

        /// <summary>
        /// Heals the player by a specified amount.
        /// </summary>
        /// <param name="amount">Amount to heal.</param>
        public void Heal(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} healed by {amount}. Health is now {Health}.");
        }

        /// <summary>
        /// Attacks a monster.
        /// </summary>
        /// <param name="target">The monster to attack.</param>
        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {AttackPower} damage!");
            target.TakeDamage(AttackPower);
        }
    }
}
