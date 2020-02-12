using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Repository
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<ActionResult<IEnumerable<Product>>> GetAll();
        Task<ActionResult<Product>> Get(int id);
        Task Update(Product ent);
        Task Add(Product ent);
        Task<ActionResult<Product>> Delete(int id);
    }
}
