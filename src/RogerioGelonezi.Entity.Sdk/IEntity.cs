namespace RogerioGelonezi.Entity.Sdk
{
    internal interface IEntity
    {
        Guid Id { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
