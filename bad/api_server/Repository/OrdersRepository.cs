using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Data;

namespace api_server.Repository
{
    public class OrdersRepository : CoreRepository<Order, apiContext>
    {
        public OrdersRepository(apiContext ctx) : base(ctx)
        {
                

        }

    }
}
