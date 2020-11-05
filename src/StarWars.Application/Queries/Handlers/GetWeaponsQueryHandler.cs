using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWars.Application.Dtos.Weapons;
using StarWars.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetWeaponsQueryHandler : IRequestHandler<GetWeaponsQuery, IReadOnlyList<GetWeaponsDto>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public GetWeaponsQueryHandler(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetWeaponsDto>> Handle(GetWeaponsQuery request, CancellationToken cancellationToken)
        {
            var weaponList = await _dataContext.Weapons.ToListAsync();
            var getWeaponDtoList = _mapper.Map<IReadOnlyList<GetWeaponsDto>>(weaponList);

            return getWeaponDtoList;
        }

    }
}