namespace DungeonExplorer
{
    /// <summary>
    /// Represents any object that can take damage.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }

    /// <summary>
    /// Represents an item that can be collected.
    /// </summary>
    public interface ICollectible
    {
        void Collect(Player player);
    }
}
