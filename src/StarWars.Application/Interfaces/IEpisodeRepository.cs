using StarWars.Domain.Entities;
using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface IEpisodeRepository
    {
        Task CreateAsync(Episode item);
    }
}