using MediatR;

namespace StarWars.Application.Commands.Characters.Delete
{
    public class DeleteCharacterCommand : IRequest
    {
        public int CharacterId { get; set; }
    }
}
