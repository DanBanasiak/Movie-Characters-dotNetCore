using FluentValidation;

namespace StarWars.Application.Commands.Characters.Delete
{
    public class DeleteCharacterCommandValidator : AbstractValidator<DeleteCharacterCommand>
    {
        public DeleteCharacterCommandValidator()
        {
            RuleFor(x => x.CharacterId)
                .NotEmpty()
                .WithMessage("CharacterId is empty");
        }
    }
}
