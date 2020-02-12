using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Repository
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<ActionResult<IEnumerable<User>>> GetAll();
        Task<ActionResult<User>> Get(int id);
        Task Update(User ent);
        Task Add(User ent);
        Task<ActionResult<User>> Delete(int id);
    }

}
