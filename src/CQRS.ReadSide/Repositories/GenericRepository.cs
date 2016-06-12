using System;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Infrastructure.Interfaces.ReadSide;
using Microsoft.EntityFrameworkCore;

namespace CQRS.ReadSide.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IInternalEntity
    {
        protected IQueryable<TEntity> Query => Context.Set<TEntity>().AsNoTracking();

        ReadContext Context { get; }

        protected GenericRepository(ReadContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void SoftDelete(TEntity entity)
        {
            var softDeletableEntity = entity as ISoftDeletable;

            if(softDeletableEntity == null)
                throw new InvalidOperationException("Entity is not soft deletable"); //just for now

            softDeletableEntity.SoftDelete();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public TEntity GetById(Guid id)
        {
            return Context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
        }
    }
}