using System;
using Microsoft.AspNetCore.Mvc;
using CQRS.Contracts.Commands;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.ReadSide.Repositories.Interfaces;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ICommandBus CommandBus { get; }
        IItemRepository ItemRepository { get; }

        public ValuesController(ICommandBus commandBus, IItemRepository itemRepository)
        {
            CommandBus = commandBus;
            ItemRepository = itemRepository;
        }
        
        [HttpGet]
        public void AddItemTest() =>
            CommandBus.Send(new AddItemCommand {Name = "Item1", Quantity = 30 });

        [HttpGet("{id}/delete")]
        public void DeleteItemTest(Guid id) =>
            CommandBus.Send(new DeleteItemCommand() {Id = id});
        

        [HttpPost("update")]
        public void UpdateItem([FromBody] UpdateItemCommand command) =>
            CommandBus.Send(command);
    }
}
