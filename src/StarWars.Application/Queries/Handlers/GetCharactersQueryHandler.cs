using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWars.Application.Dtos.Characters;
using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Dtos.Friends;
using StarWars.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IReadOnlyList<GetCharacterDto>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCharactersQueryHandler(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetCharacterDto>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            var characterList = await _dataContext.Characters
                .Include(x => x.CharacterEpisodes)
                    .ThenInclude(x => x.Episode)
                .Include(x => x.CharacterFriends)
                    .ThenInclude(x => x.Friend)
                .Include(x => x.Weapon)
                .ToListAsync();

            var getCharacterDtoList = new List<GetCharacterDto>();
            foreach (var item in characterList)
            {
                var getCharacterDto = _mapper.Map<GetCharacterDto>(item);

                foreach (var friend in item.CharacterFriends)
                {
                    var getFriendDto = _mapper.Map<GetFriendDto>(friend.Friend);
                    getCharacterDto.Friends.Add(getFriendDto);
                }

                foreach (var episode in item.CharacterEpisodes)
                {
                    var getEpisodeDto = _mapper.Map<GetEpisodeDto>(episode.Episode);
                    getCharacterDto.Episodes.Add(getEpisodeDto);
                }

                getCharacterDtoList.Add(getCharacterDto);
            }

            return getCharacterDtoList;
        }
    }
}