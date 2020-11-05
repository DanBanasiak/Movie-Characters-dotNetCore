using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWars.Application.Dtos.Episodes;
using StarWars.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetEpisodesQueryHandler : IRequestHandler<GetEpisodesQuery, IReadOnlyList<GetEpisodeDto>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public GetEpisodesQueryHandler(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetEpisodeDto>> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            var episodeList = await _dataContext.Episodes.ToListAsync();
            var getEpisodeDtoList = _mapper.Map<IReadOnlyList<GetEpisodeDto>>(episodeList);

            return getEpisodeDtoList;
        }
    }
}