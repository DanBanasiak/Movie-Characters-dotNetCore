namespace StarWars.Application.Dtos.Weapons
{
    public class CreateWeaponDto
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
    }
}