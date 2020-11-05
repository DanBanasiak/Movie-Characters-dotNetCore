using Microsoft.EntityFrameworkCore;
using StarWars.Application.Exceptions;
using StarWars.Application.Interfaces;
using StarWars.Domain.Entities;
using StarWars.Domain.SeedWork;
using StarWars.Persistence;
using System;
using System.Threading.Tasks;

namespace StarWars.Application.Data.Repositories
{
    public class CharacterFriendRepository : ICharacterFriendRepository
    {
        private readonly DataContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CharacterFriendRepository(
            DataContext dbContext,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CharacterFriend newCharacterFriend)
        {
            if (newCharacterFriend.CharacterId == newCharacterFriend.FriendId)
            {
                throw new Exception("You can't be friend of you.");
            }
            Character character = await _dbContext.Characters
                .Include(c => c.CharacterFriends).ThenInclude(cs => cs.Friend)
                .FirstOrDefaultAsync(c => c.CharacterId == newCharacterFriend.CharacterId);

            if (character == null)
            {
                throw new NotFoundException($"Character not find item {newCharacterFriend.CharacterId}");
            }

            Character friend = await _dbContext.Characters
                .Include(c => c.CharacterFriends).ThenInclude(cs => cs.Friend)
                .FirstOrDefaultAsync(c => c.CharacterId == newCharacterFriend.FriendId);

            if (friend == null)
            {
                throw new NotFoundException($"Friend not find item {newCharacterFriend.FriendId}");
            }

            var characterFriend = new CharacterFriend
            {
                Character = character,
                Friend = friend
            };

            await _dbContext.CharacterFriends.AddAsync(characterFriend);
            await _unitOfWork.CompleteAsync();
        }
    }
}