using System.Collections.Generic;
using api_server.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api_server.Repository
{
    public interface IOrderLineItemRepository
    {
        Task<OrderLineItem> Add(OrderLineItem entity);
        Task<OrderLineItem> Delete(int id);
        Task<OrderLineItem> Get(int id);
        Task<List<OrderLineItem>> GetAll();
        Task<OrderLineItem> Update(OrderLineItem entity);
    }

    public class OrderLineItemRepository : IOrderLineItemRepository
    {

        private ApiContext _ctx;

        public OrderLineItemRepository(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<OrderLineItem> Add(OrderLineItem entity)
        {
            _ctx.Set<OrderLineItem>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderLineItem> Delete(int id)
        {
            var entity = await _ctx.Set<OrderLineItem>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _ctx.Set<OrderLineItem>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<OrderLineItem> Get(int id)
        {
            return await _ctx.Set<OrderLineItem>().FindAsync(id);
        }

        public async Task<List<OrderLineItem>> GetAll()
        {
            return await _ctx.Set<OrderLineItem>().ToListAsync();
        }

        public async Task<OrderLineItem> Update(OrderLineItem entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }


    }
}
