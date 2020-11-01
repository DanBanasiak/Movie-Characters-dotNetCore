namespace StarWars.Application.Dtos.Characters
{
    public class UpdateCharacterDto
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
    }
}