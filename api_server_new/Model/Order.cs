using api_server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_server
{


    public class Order : IEntity
    {


        public int Id { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public IList<OrderLineItem> Lineitems { get; set; }

        public bool IsPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Total { get; set; }

        

    }
}
