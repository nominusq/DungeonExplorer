namespace DungeonExplorer
{
    /// <summary>
    /// Base class for all collectible items.
    /// </summary>
    public abstract class Item : ICollectible
    {
        public string Name { get; protected set; }

        public Item(string name)
        {
            Name = name;
        }

        public abstract void Use(Player player);
    }
}
