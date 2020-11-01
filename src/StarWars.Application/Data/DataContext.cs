using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;
using System;

namespace StarWars.Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<CharacterEpisode> CharacterEpisodes { get; set; }
        public DbSet<CharacterFriend> CharacterFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>().HasData(
                new Episode { EpisodeId = 1, Name = "The Phantom Menace", NumberOfEpisode = 1, ReleaseDate = new DateTime(1992) },
                new Episode { EpisodeId = 2, Name = "Attack of the Clones", NumberOfEpisode = 2, ReleaseDate = new DateTime(1994) },
                new Episode { EpisodeId = 3, Name = "Revenge of the Sith", NumberOfEpisode = 3, ReleaseDate = new DateTime(1996) },
                new Episode { EpisodeId = 4, Name = "A New Hope", NumberOfEpisode = 4, ReleaseDate = new DateTime(1998) },
                new Episode { EpisodeId = 5, Name = "The Empire Strikes Back", NumberOfEpisode = 5, ReleaseDate = new DateTime(2000) },
                new Episode { EpisodeId = 6, Name = "Return of the Jedi", NumberOfEpisode = 6, ReleaseDate = new DateTime(2002) }
                );

            modelBuilder.Entity<Character>().HasData(
                new Character { CharacterId = 1, Name = "Harry Potter" },
                new Character { CharacterId = 2, Name = "Joda" },
                new Character { CharacterId = 3, Name = "Hermiona" },
                new Character { CharacterId = 4, Name = "Luke Skywalker" }
            );

            modelBuilder.Entity<CharacterEpisode>().HasData(
                new CharacterEpisode { CharacterId = 1, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 1 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 2 },
                new CharacterEpisode { CharacterId = 2, EpisodeId = 3 }
                );

            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { WeaponId = 1, Name = "The Master Sword", Damage = 20, CharacterId = 1 },
                new Weapon { WeaponId = 3, Name = "Crystal Wand", Damage = 5, CharacterId = 2 },
                new Weapon { WeaponId = 4, Name = "Magic", Damage = 5, CharacterId = 3 },
                new Weapon { WeaponId = 5, Name = "Cystal Magic", Damage = 5, CharacterId = 4 }
                );

            modelBuilder.Entity<CharacterEpisode>()
                .HasKey(ec => new { ec.CharacterId, ec.EpisodeId });

            modelBuilder.Entity<CharacterEpisode>()
               .HasOne(bc => bc.Episode)
               .WithMany(b => b.CharacterEpisodes)
               .HasForeignKey(bc => bc.CharacterId);

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(bc => bc.Character)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(bc => bc.EpisodeId);

            modelBuilder.Entity<CharacterFriend>()
                .HasKey(ec => new { ec.CharacterId, ec.FriendId});

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(bc => bc.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(bc => bc.CharacterId);
        }
    }
}