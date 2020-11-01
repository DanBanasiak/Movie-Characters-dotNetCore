using AutoMapper;
using MediatR;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Commands.Weapons.Create.Handlers
{
    public class CreateWeaponCommandHandler : IRequestHandler<CreateWeaponCommand>
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly IMapper _mapper;
        public CreateWeaponCommandHandler(
            IWeaponRepository weaponRepository,
            IMapper mapper)
        {
            _weaponRepository = weaponRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateWeaponCommand request, CancellationToken cancellationToken)
        {
            Weapon item = _mapper.Map<Weapon>(request.CreateWeapon);
            await _weaponRepository.CreateAsync(item);
            return Unit.Value;
        }
    }
}