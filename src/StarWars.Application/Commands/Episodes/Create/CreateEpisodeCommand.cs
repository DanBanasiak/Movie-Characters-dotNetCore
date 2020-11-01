using MediatR;
using StarWars.Application.Dtos.Episodes;

namespace StarWars.Application.Commands.Episodes.Create
{
    public class CreateEpisodeCommand : IRequest
    {
        public CreateEpisodeDto CreateEpisode { get; set; }
    }
}