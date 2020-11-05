using Microsoft.EntityFrameworkCore;
using StarWars.Domain.Entities;

namespace StarWars.Persistence
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
                .HasKey(ec => new { ec.CharacterId, ec.FriendId });

            modelBuilder.Entity<CharacterFriend>()
                .HasOne(bc => bc.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(bc => bc.CharacterId);
        }
    }
}
