using System.Collections.Generic;
using CQRS.ReadSide.Entities;

namespace CQRS.ReadSide.Repositories.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<ItemEntity> GetAll();
    }
}