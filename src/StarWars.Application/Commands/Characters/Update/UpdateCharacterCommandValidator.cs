using FluentValidation;

namespace StarWars.Application.Commands.Characters.Update
{
    public class UpdateCharacterCommandValidator : AbstractValidator<UpdateCharacterCommand>
    {
        public UpdateCharacterCommandValidator()
        {
            RuleFor(x => x.CharacterId)
                .NotEmpty()
                .WithMessage("CharacterId is empty");
        }
    }
}
