using StarWars.Domain.Entities;
using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface ICharacterFriendRepository
    {
        Task CreateAsync(CharacterFriend characterFriend);
    }
}