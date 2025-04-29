using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a room in the dungeon.
    /// </summary>
    public class Room
    {
        private string description;
        public Room North { get; set; }
        public Room South { get; set; }
        public Room East { get; set; }
        public Room West { get; set; }
        public Monster Monster { get; set; }
        public Item Item { get; set; }

        /// <summary>
        /// Creates a room with the specified description.
        /// </summary>
        /// <param name="description">Description of the room.</param>
        public Room(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// Returns the description of the room.
        /// </summary>
        /// <returns>The room description.</returns>
        public string GetDescription()
        {
            return description;
        }
    }
}
