using StarWars.Domain.SeedWork;
using System.Collections.Generic;

namespace StarWars.Domain.Entities
{
    public class Character : Entity, IAggregateRoot
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }

        public Weapon Weapon { get; set; }
        public IEnumerable<CharacterEpisode> CharacterEpisodes { get; set; }
        public IEnumerable<CharacterFriend> CharacterFriends { get; set; }
    }
}