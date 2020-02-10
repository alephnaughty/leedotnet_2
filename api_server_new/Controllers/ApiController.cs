using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Model;
using api_server.Repository;
using api_server_new.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_server.Controllers
{ 

    
    [ApiController]
    public abstract class ApiController<TEntity, TRepository>
    {
        protected readonly TRepository _svc;
        
        public ApiController(TRepository svc)
        {
            
            _svc = svc;
        }


        // GET: api/[controller]
      

    }
}
