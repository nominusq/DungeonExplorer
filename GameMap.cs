using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Manages all rooms in the dungeon.
    /// </summary>
    public class GameMap
    {
        private List<Room> rooms;

        /// <summary>
        /// Initializes a new map.
        /// </summary>
        public GameMap()
        {
            rooms = new List<Room>();
        }

        /// <summary>
        /// Adds a room to the map.
        /// </summary>
        /// <param name="room">Room to add.</param>
        public void AddRoom(Room room)
        {
            if (room != null)
            {
                rooms.Add(room);
            }
        }

        /// <summary>
        /// Gets all rooms in the map.
        /// </summary>
        public IEnumerable<Room> GetRooms()
        {
            return rooms;
        }
    }
}
