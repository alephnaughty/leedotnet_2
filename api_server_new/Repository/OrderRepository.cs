using api_server.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace api_server.Repository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order entity);
        Task<Order> Delete(int id);
        Task<Order> Get(int id);
        Task<List<Order>> GetAll();
        Task<Order> Update(Order entity);
        Task<Order> GetOrder(int id);
        Task<int> Save(Order order);
        string LEE { get; set; }
    }

    public class OrderRepository : IOrderRepository
    {

        private ILogger<OrderRepository> _logger;
        private ApiContext _ctx;

        public OrderRepository(ApiContext ctx, ILogger<OrderRepository> logger) { 
            this._ctx = ctx;
            _logger = logger;
            _logger.LogInformation("OrderRepository");

        }

        public async Task<Order> Add(Order entity)
        {
            _ctx.Set<Order>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<Order> Delete(int id)
        {
            var entity = await _ctx.Set<Order>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _ctx.Set<Order>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<Order> Get(int id)
        {
            return await _ctx.Set<Order>().FindAsync(id);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _ctx.Set<Order>().ToListAsync();
        }

        public async Task<Order> Update(Order entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }
        public async Task<Order> GetOrder(int id)
        {
            var order = await this._ctx.Orders.Include(li => li.Lineitems).FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<int> Save(Order order)
        {
            if (order.Id == 0)
            {
                _ctx.Orders.Add(order);
            }
            else
            {
                _ctx.Orders.Update(order);
            }
            //var orderLineItem = new OrderLineItem {OrderId = order.Id, OrderId = OrderId, Quantity = quantity};
            //var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.Id == o.Id);

            return await _ctx.SaveChangesAsync();
            //Order.Lineitems.Add(orderLineItem);
            //return  orderLineItem;
            //var orders = await this._ctx.Orders.Include(li => li.Lineitems).FirstOrDefaultAsync(o => o.Id == id);
            //return orders;
        }


        public string LEE { get; set; }
    }
    
}
