using System;

namespace CQRS.Infrastructure.Interfaces.ReadSide
{  
    public interface IInternalEntity 
    {
        Guid Id { get; set; }
    }
}
