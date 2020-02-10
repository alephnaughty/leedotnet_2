using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldOrderController : ControllerBase
    {

        private readonly OrderRepository _repo;

        public OldOrderController(OrderRepository repository)
        {
            _repo = repository;
            
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
