using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CQRS.Contracts.Commands;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.ReadSide.Entities;
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

        // GET api/values
        [HttpGet]
        public IEnumerable<ItemEntity> AddItemTest()
        {
            CommandBus.Send(new AddItemCommand {Name = "Item1", Quantity = 30 });

            return ItemRepository.GetAll();
        }

        [HttpGet("{id}/delete")]
        public void DeleteItemTest(Guid id)
        {
            CommandBus.Send(new DeleteItemCommand() {Id = id});
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
