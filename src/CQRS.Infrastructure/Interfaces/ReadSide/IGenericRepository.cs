using System;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Interfaces.ReadSide
{
    public interface IGenericRepository<TEntity> where TEntity : class, IInternalEntity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void SoftDelete(TEntity entity);

        void Commit();

        Task CommitAsync();

        TEntity GetById(Guid id);
    }
}