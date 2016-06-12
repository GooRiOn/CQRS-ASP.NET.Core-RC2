using System;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Contracts.Commands
{
    public class DeleteItemCommand : ICommand
    {
        public Guid Id { get; }
    }
}