using StarWars.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace StarWars.Domain.Entities
{
    public class Episode : Entity, IAggregateRoot
    {
        public int EpisodeId { get; set; }
        public string Name { get; set; }
        public int NumberOfEpisode { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}