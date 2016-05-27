using System;

namespace CQRS.Contracts.Commands.Interfaces
{
    public interface ICommand
    {
        Guid Id { get; } 
    }
}