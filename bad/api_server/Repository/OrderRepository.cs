using api_server.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_server.Repository
{
    public class OrderRepository : CoreRepository<Order, apiContext>
    {

       private apiContext _ctx;
       public OrderRepository(apiContext ctx) : base(ctx)
        {
            this._ctx = ctx;
            
        }


        //public async Task<Order> Get(int id)
        //{
        //    var orders = await this._context.Orders.Include(li => li.Lineitems).FirstOrDefaultAsync(o => o.Id == id);
        //    return orders;
        //}

        //public async Task<List<Order>> GetAll()
        //{
        //    var orders = await this._context.Orders.Include(o => o.Lineitems).ToListAsync();
        //    return orders;
        //}

        //public async Task<Order> Update(Order entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
