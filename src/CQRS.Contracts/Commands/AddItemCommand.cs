using System;
using CQRS.Contracts.Commands.Interfaces;

namespace CQRS.Contracts.Commands
{
    public class AddItemCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
