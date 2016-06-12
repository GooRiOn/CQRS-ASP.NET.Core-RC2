using System.Collections.Generic;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.ReadSide.Entities;

namespace CQRS.ReadSide.Repositories.Interfaces
{
    public interface IItemRepository : IGenericRepository<ItemEntity>
    {
        IEnumerable<ItemEntity> GetAll();
    }
}