namespace RogerioGelonezi.Entity.Sdk
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}