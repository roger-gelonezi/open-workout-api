namespace Repository.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }

        TEntity? SelectById(Guid id);
        Task<TEntity?> SelectByIdAsync(Guid id, CancellationToken cancellationToken);

        bool Exists(Guid id);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);

        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

        void Delete(Guid id);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}