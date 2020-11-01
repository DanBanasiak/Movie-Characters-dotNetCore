using AutoMapper;
using MediatR;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.Characters.Create.Handlers
{
    public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        public CreateCharacterCommandHandler(
            ICharacterRepository characterRepository,
            IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
        {
            Character character = _mapper.Map<Character>(request.CreateCharacter);
            await _characterRepository.CreateAsync(character);
            return Unit.Value;
        }
    }
}