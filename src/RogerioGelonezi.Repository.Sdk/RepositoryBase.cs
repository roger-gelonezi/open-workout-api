using Microsoft.EntityFrameworkCore;
using RogerioGelonezi.Entity.Sdk;

namespace RogerioGelonezi.Repository.Sdk
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All => _dbSet;

        public virtual TEntity? SelectById(Guid id)
            => _dbSet.Find(id);

        public virtual async Task<TEntity?> SelectByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync(new object[] { id }, cancellationToken);

        public virtual bool Exists(Guid id)
            => _dbSet.Any(x => Equals(x.Id, id));

        public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken)
            => await _dbSet.AnyAsync(x => Equals(x.Id, id), cancellationToken);

        public virtual void Insert(TEntity entity)
        {
            if (Exists(entity.Id))
                throw new ArgumentException("The given Id already exists in the table");

            entity.LastUpdate = DateTime.Now;

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken))
                throw new ArgumentException("The given Id already exists in the table");

            entity.LastUpdate = DateTime.Now;

            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            if (Exists(entity.Id) == false)
                throw new ArgumentException("The given Id do not exists in the table");

            entity.LastUpdate = DateTime.Now;

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken) == false)
                throw new ArgumentException("The given Id do not exists in the table");

            entity.LastUpdate = DateTime.Now;

            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(true, cancellationToken);
        }

        public virtual void Delete(Guid id)
        {
            if (Exists(id) == false)
                return;

            var entity = SelectById(id);
            if (entity == null)
                return;

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(id, cancellationToken) == false)
                return;

            var entity = await SelectByIdAsync(id, cancellationToken);
            if (entity == null) 
                return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(true, cancellationToken);
        }
    }
}
