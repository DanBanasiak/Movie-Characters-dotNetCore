using FluentValidation;

namespace StarWars.Application.Commands.Characters.Create
{
    public class CreateCharacterCommandValidator : AbstractValidator<CreateCharacterCommand>
    {
        public CreateCharacterCommandValidator()
        {
            //TODO
            //RuleFor(x => x.CreateCharacter.Name)
            //    .NotEmpty()
            //    .WithMessage("Name is empty");
        }
    }
}