using AutoMapper;
using MediatR;
using StarWars.Application.Commands.CharacterEpisodes.Create;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.CharacterEpisodes.Handlers
{
    public class CreateCharacterEpisodesCommandHandler : IRequestHandler<CreateCharacterEpisodeCommand>
    {
        private readonly ICharacterEpisodeRepository _characterEpisodeRepository;
        private readonly IMapper _mapper;
        public CreateCharacterEpisodesCommandHandler(
            ICharacterEpisodeRepository characterEpisodeRepository,
            IMapper mapper)
        {
            _characterEpisodeRepository = characterEpisodeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCharacterEpisodeCommand request, CancellationToken cancellationToken)
        {
            CharacterEpisode item = _mapper.Map<CharacterEpisode>(request.CreateCharacterEpisode);
            await _characterEpisodeRepository.CreateAsync(item);
            return Unit.Value;
        }
    }
}
