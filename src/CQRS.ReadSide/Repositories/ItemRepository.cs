using System.Collections.Generic;
using System.Linq;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.ReadSide.Entities;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.ReadSide.Repositories
{
    public class ItemRepository : GenericRepository<ItemEntity>, IItemRepository
    {
        public ItemRepository(ReadContext context) : base(context)
        {
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            return Query.Where(i => !i.IsDeleted).ToList();
        }
    }
}