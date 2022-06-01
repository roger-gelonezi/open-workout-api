namespace Entities.Abstractions
{
    internal interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime LastUpdate { get; set; }
    }
}
