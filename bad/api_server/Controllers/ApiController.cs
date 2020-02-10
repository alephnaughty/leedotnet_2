using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Model;
using api_server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_server.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repo;
        //private readonly ILogger _logger;

        public ApiController(TRepository repository)
        {
            //_logger = logger;
            _repo = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repo.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var ent = await _repo.Get(id);
            if (ent == null)
            {
                return NotFound();
            }
            return ent;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity ent)
        {
            if (id != ent.Id)
            {
                return BadRequest();
            }

            await _repo.Update(ent);
                return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity ent)
        {
            await _repo.Add(ent);
            return CreatedAtAction("Get", new { id = ent.Id }, ent);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var ent = await _repo.Delete(id);
            if (ent == null)
            {
                return NotFound();
            }
            return ent;
        }

    }
}
