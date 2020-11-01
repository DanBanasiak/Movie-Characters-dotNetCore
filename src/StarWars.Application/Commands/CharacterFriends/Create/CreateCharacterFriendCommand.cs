using MediatR;
using StarWars.Application.Dtos.CharacterFriends;

namespace StarWars.Application.Commands.Characters
{
    public class CreateCharacterFriendCommand : IRequest
    {
        public CreateCharacterFriendDto CreateCharacterFriend { get; set; }
    }
}