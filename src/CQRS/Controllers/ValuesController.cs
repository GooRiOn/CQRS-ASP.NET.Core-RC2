using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CQRS.Contracts.Commands;
using CQRS.Infrastructure.Interfaces.Busses;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ICommandBus CommandBus { get; }

        public ValuesController(ICommandBus commandBus)
        {
            CommandBus = commandBus; 
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            CommandBus.Send(new AddItemCommand {Name = "Item1", Quantity = 30 });

            return new string[] { "value1", "value2" };
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
