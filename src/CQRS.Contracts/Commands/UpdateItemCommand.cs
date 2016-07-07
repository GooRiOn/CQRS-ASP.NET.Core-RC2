using System;
using CQRS.Infrastructure.Interfaces.Contracts;

namespace CQRS.Contracts.Commands
{
    public class UpdateItemCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
