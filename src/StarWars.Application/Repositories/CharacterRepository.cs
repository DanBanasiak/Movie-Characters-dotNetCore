using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StarWars.Application.Exceptions;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StarWars.Application.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly DataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CharacterRepository(
            DataContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Character character)
        {
            await _dbContext.Characters.AddAsync(character);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(int characterId, Character newCharacter)
        {
            Character character = await _dbContext.Characters
                .Include(c => c.Weapon)
                .Include(c => c.CharacterEpisodes).ThenInclude(cs => cs.Episode)
                .FirstOrDefaultAsync(c => c.CharacterId == characterId);

            if (character == null)
                throw new Exception("Could not find item");

            character.CharacterId = characterId;
            character.Name = newCharacter.Name;
            character.Defense = newCharacter.Defense;
            character.Strength = newCharacter.Strength;
            character.Intelligence = newCharacter.Intelligence;

            EntityEntry<Character> entry = _dbContext.Characters.Update(character);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbContext.Characters.FindAsync(id);
            if (item == null)
                throw new NotFoundException($"Could not find item {id}");

            //TODO: Delete also characterEpisode && characterFriend

            EntityEntry<Character> entry = _dbContext.Remove(item);
            await _unitOfWork.CompleteAsync();
        }
    }
}