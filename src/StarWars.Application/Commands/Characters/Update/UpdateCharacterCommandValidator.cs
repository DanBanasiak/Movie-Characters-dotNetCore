using FluentValidation;

namespace StarWars.Application.Commands.Characters.Update
{
    public class UpdateCharacterCommandValidator : AbstractValidator<UpdateCharacterCommand>
    {
        public UpdateCharacterCommandValidator()
        {
            //TODO
            //RuleFor(x => x.CharacterId)
            //    .NotEmpty()
            //    .WithMessage("CharacterId is empty");
        }
    }
}
