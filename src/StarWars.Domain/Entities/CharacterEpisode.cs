using System;

namespace StarWars.Domain.Entities
{
    public class CharacterEpisode
    {
        public int EpisodeId { get; set; }
        public int CharacterId { get; set; }

        public Episode Episode { get; set; }
        public Character Character { get; set; }
    }
}