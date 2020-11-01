using System;

namespace StarWars.Domain.Entities
{
    public class CharacterFriend
    {
        public int FriendId { get; set; }
        public int CharacterId { get; set; }

        public Character Friend { get; set; }
        public Character Character { get; set; }
    }
}