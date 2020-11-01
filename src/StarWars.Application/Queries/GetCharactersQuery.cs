using MediatR;
using StarWars.Application.Dtos.Characters;
using StarWars.Domain.Specifications;
using System.Collections.Generic;

namespace StarWars.Application.Queries
{
    public class GetCharactersQuery : IRequest<IReadOnlyList<GetCharacterDto>>
    {
        public ProductSpecParams ProductSpecParams { get; set; }
    }
}
