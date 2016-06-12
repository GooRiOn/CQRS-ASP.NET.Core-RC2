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

        void IGenericRepository<TEntity>.Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        void IGenericRepository<TEntity>.Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        void IGenericRepository<TEntity>.SoftDelete(TEntity entity)
        {
            var softDeletableEntity = entity as ISoftDeletable;

            if(softDeletableEntity == null)
                throw new InvalidOperationException("Entity is not soft deletable"); //just for now

            softDeletableEntity.SoftDelete();
        }

        void IGenericRepository<TEntity>.Commit()
        {
            Context.SaveChanges();
        }

        async Task IGenericRepository<TEntity>.CommitAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}