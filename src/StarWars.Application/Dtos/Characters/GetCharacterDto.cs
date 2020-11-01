using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Dtos.Friends;
using System;
using System.Collections.Generic;

namespace StarWars.Application.Dtos.Characters
{
    public class GetCharacterDto
    {
        public DateTime CreatedAt { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public List<GetEpisodeDto> Episodes { get; set; }
        public List<GetFriendDto> Friends { get; set; }

        public GetCharacterDto()
        {
            Episodes = new List<GetEpisodeDto>();
            Friends = new List<GetFriendDto>();
        }
    }
}