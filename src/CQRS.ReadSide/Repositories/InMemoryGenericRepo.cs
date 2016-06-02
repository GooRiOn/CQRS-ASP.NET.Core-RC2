using CQRS.Infrastructure.Interfaces.ReadSide;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CQRS.ReadSide.Repositories
{  
    public class InMemoryGenericRepo<TEntity> : IInMemoryGenericRepo<TEntity> where TEntity : class
    {
        HashSet<TEntity> SampleData { get; } = new HashSet<TEntity>();

        public void Insert(TEntity entity)
        {
            SampleData.Add(entity);
            Console.WriteLine("entity created");
        }

        public void Delete(TEntity entity)
        {
            SampleData.Remove(entity);
        }

        public void Update(TEntity entity)
        {
           //
        }

        public IEnumerable<TEntity> GetAll()
        {
            return SampleData;
        }
    }
}
