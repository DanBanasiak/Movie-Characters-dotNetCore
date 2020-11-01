using StarWars.Domain.Entities;
using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface ICharacterEpisodeRepository
    {
        Task CreateAsync(CharacterEpisode characterEpisode);
    }
}