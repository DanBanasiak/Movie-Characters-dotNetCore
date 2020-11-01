using StarWars.Application.Data;
using StarWars.Application.Data.Repositories;
using StarWars.Domain.Entities;
using StarWars.UnitTests.Mocks;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.UnitTests
{
    public class CharacterFriendTests : SqliteDatabase
    {
        [Fact]
        public async Task After_add_the_same_characterId_and_friendId_should_throw_exception()
        {
            //arrange
            var newCharacterFriend = new CharacterFriend()
            {
                CharacterId = 1,
                FriendId = 1
            };
            var repository = new CharacterFriendRepository(DbContext, new UnitOfWork(DbContext));

            //act, assert
            await Assert.ThrowsAsync<Exception>(() => repository.CreateAsync(newCharacterFriend));
        }
    }
}