using System;
using DungeonExplorer;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a monster in the dungeon.
    /// </summary>
    public class Monster : Creature
    {
        public Monster(string name, int health, int attackPower)
            : base(name, health, attackPower)
        {
        }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} strikes {target.Name} for {AttackPower} damage!");
            target.TakeDamage(AttackPower);
        }
    }
}
