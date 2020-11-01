using StarWars.Domain.Entities;
using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface ICharacterRepository
    {
        Task CreateAsync(Character character);
        Task UpdateAsync(int characterId, Character character);
        Task DeleteAsync(int id);
    }
}