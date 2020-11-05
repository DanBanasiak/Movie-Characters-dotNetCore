using AutoMapper;
using StarWars.Application.Dtos.CharacterEpisodes;
using StarWars.Application.Dtos.CharacterFriends;
using StarWars.Application.Dtos.Characters;
using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Dtos.Friends;
using StarWars.Application.Dtos.Weapons;
using StarWars.Domain.Entities;

namespace StarWars.Api.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateCharacterEpisodeDto, CharacterEpisode>();
            CreateMap<CreateCharacterFriendDto, CharacterFriend>();

            CreateMap<CreateCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();

            CreateMap<CreateEpisodeDto, Episode>();
            CreateMap<CreateWeaponDto, Weapon>();
            CreateMap<Character, GetCharacterDto>();
            CreateMap<Character, GetFriendDto>()
                .ForMember(x => x.FriendName, opt => opt.MapFrom(src => src.Name));
            CreateMap<Episode, GetEpisodeDto>();
        }
    }
}