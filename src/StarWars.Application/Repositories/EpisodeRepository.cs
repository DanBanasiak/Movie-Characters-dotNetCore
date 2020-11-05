using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using StarWars.Domain.SeedWork;
using StarWars.Persistence;
using System;
using System.Threading.Tasks;

namespace StarWars.Application.Data.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public EpisodeRepository(
            DataContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(Episode item)
        {
            await _dbContext.Episodes.AddAsync(item);
            await _unitOfWork.CompleteAsync();
        }
    }
}