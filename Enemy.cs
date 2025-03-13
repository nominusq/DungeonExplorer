namespace DungeonExplorer
{
    /// <summary>
    /// Represents an enemy in the dungeon.
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// Gets the name of the enemy.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the health of the enemy.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets the attack power of the enemy.
        /// </summary>
        public int AttackPower { get; private set; }

        /// <summary>
        /// Creates an enemy with specified stats.
        /// </summary>
        /// <param name="name">Name of the enemy.</param>
        /// <param name="health">Health points of the enemy.</param>
        /// <param name="attackPower">Attack power of the enemy.</param>
        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }
    }
}
