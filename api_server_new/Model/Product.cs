using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiServer.Model;

namespace ApiServer
{
    public class Product : IEntity
    {
        //Id
        public int Id { get; set; }

        //Product Name
        public string Name { get; set; }

        public String Description { get; set; }

        public String Color { get; set; }
        public String Size { get; set; }

        public int Inventory { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Cost { get; set; }


    }
}