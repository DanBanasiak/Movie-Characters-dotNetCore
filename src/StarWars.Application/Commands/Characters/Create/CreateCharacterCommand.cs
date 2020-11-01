using MediatR;
using StarWars.Application.Dtos.Characters;

namespace StarWars.Application.Commands.Characters.Create
{
    public class CreateCharacterCommand : IRequest
    {
        public CreateCharacterDto CreateCharacter { get; set; }
    }
}