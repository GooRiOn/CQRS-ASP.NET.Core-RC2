using System;
using CQRS.Infrastructure.Interfaces.ReadSide;

namespace CQRS.ReadSide.Entities
{
    public class ItemEntity : IInternalEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
