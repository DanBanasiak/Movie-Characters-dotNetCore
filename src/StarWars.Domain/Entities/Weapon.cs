using StarWars.Domain.SeedWork;

namespace StarWars.Domain.Entities
{
    public class Weapon : Entity, IAggregateRoot
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}