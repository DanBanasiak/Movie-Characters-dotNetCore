using FluentValidation;
using StarWars.Application.Commands.Characters;

namespace StarWars.Application.Commands.CharacterFriends.Create
{
    public class CreateCharacterFriendCommandValidator : AbstractValidator<CreateCharacterFriendCommand>
    {
        public CreateCharacterFriendCommandValidator()
        {
            RuleFor(x => x.CreateCharacterFriend.CharacterId)
                .NotEmpty()
                .WithMessage("CharacterId is empty");
            RuleFor(x => x.CreateCharacterFriend.FriendId)
                .NotEmpty()
                .WithMessage("FriendId is empty");
        }
    }
}