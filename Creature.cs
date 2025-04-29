namespace DungeonExplorer
{
    /// <summary>
    /// Abstract base class for all creatures in the game.
    /// </summary>
    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }

        public Creature(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public abstract void Attack(Creature target);
    }
}
