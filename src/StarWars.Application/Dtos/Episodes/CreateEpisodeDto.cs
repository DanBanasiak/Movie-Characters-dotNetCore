using System;

namespace StarWars.Application.Dtos.Episodes
{
    public class CreateEpisodeDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfEpisode { get; set; }
    }
}