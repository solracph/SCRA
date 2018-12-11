using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCRA.Data.Common.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        protected Repository()
        {
        }

        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException();
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected DbContext DbContext { get; set; }

        public virtual IList<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual IList<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            var query =
                includedProperties.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(DbSet,
                    (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
                dbEntityEntry = DbContext.Entry(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void AddAndAttach(TEntity entity) 
        {
            DbSet.Add(entity);
            DbSet.Attach(entity);
        }

        public virtual void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if (entity == null) return;
            Delete(entity);
        }
    }
}
