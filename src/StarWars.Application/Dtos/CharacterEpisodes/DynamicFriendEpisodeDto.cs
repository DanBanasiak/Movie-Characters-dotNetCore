using System;

namespace StarWars.Application.Dtos.CharacterEpisodes
{
    public class DynamicFriendEpisodeDto
    {
        public int FriendId { get; set; }
        public string FriendName { get; set; }
        public int EpisodeId { get; set; }
        public string EpisodeName { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
    }
}