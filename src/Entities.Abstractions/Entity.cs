namespace Entities.Abstractions
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}