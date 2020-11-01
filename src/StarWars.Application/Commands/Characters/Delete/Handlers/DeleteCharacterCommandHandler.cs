using AutoMapper;
using MediatR;
using StarWars.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.Characters.Delete.Handlers
{
    public class DeleteCharacterCommandHandler : IRequestHandler<DeleteCharacterCommand>
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        public DeleteCharacterCommandHandler(ICharacterRepository characterRepository, IMapper mapper)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
        {
            await _characterRepository.DeleteAsync(request.CharacterId);
            return Unit.Value;
        }
    }
}