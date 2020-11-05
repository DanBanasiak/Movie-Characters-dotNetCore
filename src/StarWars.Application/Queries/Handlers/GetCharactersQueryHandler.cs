using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StarWars.Application.Dtos.Characters;
using StarWars.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IReadOnlyList<GetCharacterDto>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GetCharactersQueryHandler(
            DataContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GetCharacterDto>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            var characterList = await _dataContext.Characters.ToListAsync();
            var getCharacterDtoList = _mapper.Map<IReadOnlyList<GetCharacterDto>>(characterList);
            return getCharacterDtoList;
        }
    }
}