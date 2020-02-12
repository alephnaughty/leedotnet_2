using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Model;

namespace ApiServer
{
    public class OrderLineItem : IEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }



        //Options?


    }
}
