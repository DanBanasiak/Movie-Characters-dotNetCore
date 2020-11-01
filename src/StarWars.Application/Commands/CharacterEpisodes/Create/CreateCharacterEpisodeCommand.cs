using MediatR;
using StarWars.Application.Dtos.CharacterEpisodes;

namespace StarWars.Application.Commands.CharacterEpisodes.Create
{
    public class CreateCharacterEpisodeCommand : IRequest
    {
        public CreateCharacterEpisodeDto CreateCharacterEpisode { get; set; }
    }
}