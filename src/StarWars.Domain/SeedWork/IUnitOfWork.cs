using System.Threading.Tasks;

namespace StarWars.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}