namespace DungeonExplorer
{
    /// <summary>
    /// Represents a potion that heals the player.
    /// </summary>
    public class Potion : Item
    {
        private int healAmount;

        public Potion(string name, int healAmount)
            : base(name)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Player player)
        {
            player.Heal(healAmount);
        }
    }
}
