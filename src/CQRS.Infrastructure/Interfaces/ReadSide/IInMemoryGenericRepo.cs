using System;
using System.Collections.Generic;

namespace CQRS.Infrastructure.Interfaces.ReadSide
{
    public interface IInMemoryGenericRepo<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
