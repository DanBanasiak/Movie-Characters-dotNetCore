using MediatR;
using StarWars.Application.Dtos.Characters;

namespace StarWars.Application.Commands.Characters.Update
{
    public class UpdateCharacterCommand : IRequest
    {
        public int CharacterId { get; set; }
        public UpdateCharacterDto UpdateCharacter { get; set; }
    }
}
