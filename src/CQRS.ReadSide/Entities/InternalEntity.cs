using System;
using CQRS.Infrastructure.Interfaces.ReadSide;

namespace CQRS.ReadSide.Entities
{
    public abstract class InternalEntity : IInternalEntity, ISoftDeletable
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; protected set; }

        protected InternalEntity()
        {
            IsDeleted = false;
        }

        void ISoftDeletable.SoftDelete()
        {
            IsDeleted = true;
        }
    }
}