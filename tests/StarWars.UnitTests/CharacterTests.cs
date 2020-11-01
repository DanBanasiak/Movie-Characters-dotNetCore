using FluentAssertions;
using StarWars.Application.Data;
using StarWars.Application.Data.Repositories;
using StarWars.Application.Exceptions;
using StarWars.Domain.Entities;
using StarWars.UnitTests.Mocks;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.UnitTests
{
    public class CharacterTests : SqliteDatabase
    {
        [Fact]
        public async Task After_added_character_should_found_new_character()
        {
            //arrange
            var newCharacter = new Character()
            {
                CharacterId = 100,
                Name = "Yoda"
            };
            var repository = new CharacterRepository(DbContext, new UnitOfWork(DbContext));

            //act
            await repository.CreateAsync(newCharacter);

            //assert
            Assert.Equal(newCharacter, DbContext.Characters.Find(newCharacter.CharacterId));
        }

        [Fact]
        public async Task After_modified_character_should_give_modified_character()
        {
            //arrange
            var newCharacter = new Character()
            {
                CharacterId = 100,
                Name = "Yoda"
            };
            var repository = new CharacterRepository(DbContext, new UnitOfWork(DbContext));

            //act
            await repository.CreateAsync(newCharacter);
            newCharacter.Name = "Luke";
            await repository.UpdateAsync(newCharacter.CharacterId, newCharacter);

            //assert
            Assert.Equal(newCharacter, DbContext.Characters.Find(newCharacter.CharacterId));
        }


        [Fact]
        public async Task After_deleted_character_should_not_give_deleted_character()
        {
            //arrange
            var newCharacter = new Character()
            {
                CharacterId = 100,
                Name = "Yoda"
            };
            var repository = new CharacterRepository(DbContext, new UnitOfWork(DbContext));

            //act
            await repository.CreateAsync(newCharacter);
            await repository.DeleteAsync(newCharacter.CharacterId);

            //assert
            DbContext.Characters.Find(newCharacter.CharacterId).Should().BeNull();
        }


        [Fact]
        public async Task Given_invalid_character_id_during_delete_should_throw_an_exception()
        {
            //arrange
            var invalidCharacterId = 0;
            var repository = new CharacterRepository(DbContext, new UnitOfWork(DbContext));

            //act, assert
            await Assert.ThrowsAsync<NotFoundException>(() => repository.DeleteAsync(invalidCharacterId));
        }
    }
}