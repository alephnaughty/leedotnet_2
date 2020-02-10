using api_server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api_server.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private apiContext _context;

        public ProductRepository(apiContext ctx)
        {
            this._context = ctx;
        }

        public Task<Product> Add(Product p)
        {
            
            //this._context.Products
            throw new NotImplementedException();
        }
        public async Task<int> Add(String name, String description, int inventory)
        {  
         
            var p = new Product{ Name = "Name", Description = "Desc", Inventory = 100 };
            this._context.Products.Add(p);
            IList<String> l = new List<String>();
            

            return await this._context.SaveChangesAsync();
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
