using System;

namespace StarWars.Domain.SeedWork
{
    public abstract class Entity
    {
        public DateTime CreatedAt { get; set; }
        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}