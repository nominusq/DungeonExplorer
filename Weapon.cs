namespace DungeonExplorer
{
    /// <summary>
    /// Represents a weapon that boosts attack power.
    /// </summary>
    public class Weapon : Item
    {
        private int attackBoost;

        public Weapon(string name, int attackBoost)
            : base(name)
        {
            this.attackBoost = attackBoost;
        }

        public override void Use(Player player)
        {
            player.BoostAttack(attackBoost);
        }
    }
}
