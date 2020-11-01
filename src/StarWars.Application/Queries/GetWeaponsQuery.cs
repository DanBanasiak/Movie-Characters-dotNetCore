using MediatR;
using StarWars.Application.Dtos.Weapons;
using System.Collections.Generic;

namespace StarWars.Application.Queries
{
    public class GetWeaponsQuery : IRequest<IReadOnlyList<GetWeaponsDto>> { }
}