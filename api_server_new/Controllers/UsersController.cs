using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiServer;
using ApiServer.Repository;
using api_server_new.Repository;
using api_server_new.Services;
using Microsoft.Extensions.Logging;

namespace ApiServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _svc;

        public UsersController(IUserService svc, ILogger<UsersController> logger)
        {

            _logger = logger;
            _svc = svc;
            logger.LogInformation("ctor");
            logger.LogInformation("svc is ", svc);
            //this._repo = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _svc.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var ent = await _svc.Get(id);
            if (ent == null)
            {
                return NotFound();
            }

            return ent;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User ent)
        {
            if (id != ent.Id)
            {
                return BadRequest();
            }

            await _svc.Update(ent);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<User>> Post(User ent)
        {
            await _svc.Add(ent);
            return CreatedAtAction("Get", new { id = ent.Id }, ent);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var ent = await _svc.Delete(id);
            if (ent == null)
            {
                return NotFound();
            }

            return ent;
        }

    }
}
