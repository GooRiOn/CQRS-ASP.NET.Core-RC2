using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CQRS.Contracts.Commands;
using CQRS.Infrastructure.Interfaces.Busses;
using CQRS.Infrastructure.Interfaces.ReadSide;
using CQRS.Domain.Aggregates;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ICommandBus CommandBus { get; }
        IInMemoryGenericRepo<Item> Repo { get; }

        public ValuesController(ICommandBus commandBus, IInMemoryGenericRepo<Item> repo)
        {
            CommandBus = commandBus;
            Repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            CommandBus.Send(new AddItemCommand {Name = "Item1", Quantity = 30 });

            return Repo.GetAll();
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
