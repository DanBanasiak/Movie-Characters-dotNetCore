using AutoMapper;
using MediatR;
using StarWars.Application.Commands.Characters;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.CharacterFriends.Create.Handlers
{
    public class CreateCharacterFriendCommandHandler : IRequestHandler<CreateCharacterFriendCommand>
    {
        private readonly ICharacterFriendRepository _characterFriendRepository;
        private readonly IMapper _mapper;
        public CreateCharacterFriendCommandHandler(
            ICharacterFriendRepository characterFriendRepository,
            IMapper mapper)
        {
            _characterFriendRepository = characterFriendRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCharacterFriendCommand request, CancellationToken cancellationToken)
        {
            CharacterFriend item = _mapper.Map<CharacterFriend>(request.CreateCharacterFriend);
            await _characterFriendRepository.CreateAsync(item);
            return Unit.Value;
        }
    }
}
