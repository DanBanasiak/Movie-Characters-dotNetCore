using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace StarWars.Application.Data.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly DataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public WeaponRepository(
            DataContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Weapon weapon)
        {
            await _dbContext.Weapons.AddAsync(weapon);
            await _unitOfWork.CompleteAsync();
        }
    }
}