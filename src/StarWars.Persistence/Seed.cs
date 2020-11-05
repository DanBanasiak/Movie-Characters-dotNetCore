using StarWars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Episodes.Any())
            {
                var episodes = new List<Episode>()
                {
                    new Episode { EpisodeId = 1, Name = "The Phantom Menace", NumberOfEpisode = 1, ReleaseDate = new DateTime(1992) },
                    new Episode { EpisodeId = 2, Name = "Attack of the Clones", NumberOfEpisode = 2, ReleaseDate = new DateTime(1994) },
                    new Episode { EpisodeId = 3, Name = "Revenge of the Sith", NumberOfEpisode = 3, ReleaseDate = new DateTime(1996) },
                    new Episode { EpisodeId = 4, Name = "A New Hope", NumberOfEpisode = 4, ReleaseDate = new DateTime(1998) },
                    new Episode { EpisodeId = 5, Name = "The Empire Strikes Back", NumberOfEpisode = 5, ReleaseDate = new DateTime(2000) },
                    new Episode { EpisodeId = 6, Name = "Return of the Jedi", NumberOfEpisode = 6, ReleaseDate = new DateTime(2002) }
                };


                var characters = new List<Character>()
                {
                    new Character { CharacterId = 1, Name = "Harry Potter" },
                    new Character { CharacterId = 2, Name = "Joda" },
                    new Character { CharacterId = 3, Name = "Hermiona" },
                    new Character { CharacterId = 4, Name = "Luke Skywalker" }
                };

                var characterEpisodes = new List<CharacterEpisode>()
                {
                    new CharacterEpisode { CharacterId = 1, EpisodeId = 1 },
                    new CharacterEpisode { CharacterId = 2, EpisodeId = 1 },
                    new CharacterEpisode { CharacterId = 2, EpisodeId = 2 },
                    new CharacterEpisode { CharacterId = 2, EpisodeId = 3 }
                };

                var characterFriends = new List<CharacterFriend>()
                {
                    new CharacterFriend { CharacterId = 1, FriendId = 1 },
                    new CharacterFriend { CharacterId = 2, FriendId = 1 },
                    new CharacterFriend { CharacterId = 2, FriendId = 2 },
                    new CharacterFriend { CharacterId = 2, FriendId = 3 }
                };

                var weapons = new List<Weapon>()
                {
                    new Weapon { WeaponId = 1, Name = "The Master Sword", Damage = 20, CharacterId = 1 },
                    new Weapon { WeaponId = 3, Name = "Crystal Wand", Damage = 5, CharacterId = 2 },
                    new Weapon { WeaponId = 4, Name = "Magic", Damage = 5, CharacterId = 3 },
                    new Weapon { WeaponId = 5, Name = "Cystal Magic", Damage = 5, CharacterId = 4 }
                };

                await context.Episodes.AddRangeAsync(episodes);
                await context.Characters.AddRangeAsync(characters);
                await context.CharacterFriends.AddRangeAsync(characterFriends);
                await context.CharacterEpisodes.AddRangeAsync(characterEpisodes);
                await context.Weapons.AddRangeAsync(weapons);
                await context.SaveChangesAsync();
            }
        }
    }
}