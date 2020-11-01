using AutoMapper;
using MediatR;
using StarWars.Application.Commands.Characters;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.Episodes.Create.Handlers
{
    public class CreateEpisodeCommandHandler : IRequestHandler<CreateEpisodeCommand>
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        public CreateEpisodeCommandHandler(
            IEpisodeRepository episodeRepository,
            IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateEpisodeCommand request, CancellationToken cancellationToken)
        {
            Episode item = _mapper.Map<Episode>(request.CreateEpisode);
            await _episodeRepository.CreateAsync(item);
            return Unit.Value;
        }
    }
}
