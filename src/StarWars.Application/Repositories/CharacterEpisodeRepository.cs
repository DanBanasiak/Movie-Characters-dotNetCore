using Microsoft.EntityFrameworkCore;
using StarWars.Application.Exceptions;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace StarWars.Application.Data.Repositories
{
    public class CharacterEpisodeRepository : ICharacterEpisodeRepository
    {
        private readonly DataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CharacterEpisodeRepository(
            DataContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CharacterEpisode newCharacterEpisode)
        {
            Character character = await _dbContext.Characters
                .Include(c => c.Weapon)
                .Include(c => c.CharacterEpisodes).ThenInclude(cs => cs.Episode)
                .FirstOrDefaultAsync(c => c.CharacterId == newCharacterEpisode.CharacterId);
            if (character == null)
            {
                throw new NotFoundException($"Episode not find item {newCharacterEpisode.CharacterId}");
            }

            Episode episode = await _dbContext.Episodes
                .FirstOrDefaultAsync(s => s.EpisodeId == newCharacterEpisode.EpisodeId);

            if (episode == null)
            {
                throw new NotFoundException($"Episode not find item {newCharacterEpisode.EpisodeId}");
            }

            CharacterEpisode characterEpisode = new CharacterEpisode
            {
                Character = character,
                Episode = episode
            };

            await _dbContext.CharacterEpisodes.AddAsync(characterEpisode);
            await _unitOfWork.CompleteAsync();
        }
    }
}