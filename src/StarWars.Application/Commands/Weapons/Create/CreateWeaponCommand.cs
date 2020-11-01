using MediatR;
using StarWars.Application.Dtos.Weapons;

namespace StarWars.Application.Commands.Weapons.Create
{
    public class CreateWeaponCommand : IRequest
    {
        public CreateWeaponDto CreateWeapon { get; set; }
    }
}