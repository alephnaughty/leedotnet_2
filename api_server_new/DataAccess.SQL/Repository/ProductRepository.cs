using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer;
using ApiServer.DataAccess.SQL;
using ApiServer.Model;
using ApiServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_server_new.Repository
{

    public class ProductRepository : IProductRepository
    {
        private ApiContext _ctx;

        public ProductRepository(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> Add(Product entity)
        {
            _ctx.Set<Product>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Delete(int id)
        {
            var entity = await _ctx.Set<Product>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _ctx.Set<Product>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<Product> Get(int id)
        {
            return await _ctx.Set<Product>().FindAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _ctx.Set<Product>().ToListAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }

    }

}