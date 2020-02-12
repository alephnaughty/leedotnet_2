using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiServer.Model;

namespace ApiServer
{

    public enum OrderStatus
    {


        Open=0,Closed=1,Cancelled=2
    }


    public class Order : IEntity
    {


        public int Id { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateTime Created { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }



    }

}
