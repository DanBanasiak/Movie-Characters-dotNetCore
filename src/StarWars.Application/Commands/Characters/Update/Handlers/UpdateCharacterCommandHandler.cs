using AutoMapper;
using MediatR;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.Characters.Update.Handlers
{
    public class UpdateCharacterCommandHandler : IRequestHandler<UpdateCharacterCommand>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        public UpdateCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCharacterCommand request, CancellationToken cancellationToken)
        {
            Character character = _mapper.Map<Character>(request.UpdateCharacter);
            await _characterRepository.UpdateAsync(request.CharacterId, character);
            return Unit.Value;

        }
    }
}