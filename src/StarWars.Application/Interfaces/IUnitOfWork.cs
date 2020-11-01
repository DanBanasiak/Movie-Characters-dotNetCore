using System.Threading.Tasks;

namespace StarWars.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}