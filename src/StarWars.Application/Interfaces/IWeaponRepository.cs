using StarWars.Domain.Entities;
using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface IWeaponRepository
    {
        Task CreateAsync(Weapon weapon);
    }
}