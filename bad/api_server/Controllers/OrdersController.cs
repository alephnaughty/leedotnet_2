using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Model;
using api_server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api_server.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ApiController<Order , OrderRepository>
    {

        private readonly IRepository<Order> _repo;

        //public OrderController(IRepository<Order> repository)
        //{
        //    this.repository = repository;
            
        //}

        //// GET: api/Order
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Order/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Order
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Order/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        public OrdersController(OrderRepository repository) : base(repository)
        {

        }

        
    }
}
