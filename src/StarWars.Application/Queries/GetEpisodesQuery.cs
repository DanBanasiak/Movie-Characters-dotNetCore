using MediatR;
using StarWars.Application.Dtos.Episodes;
using System.Collections.Generic;

namespace StarWars.Application.Queries
{
    public class GetEpisodesQuery : IRequest<IReadOnlyList<GetEpisodeDto>> { }
}