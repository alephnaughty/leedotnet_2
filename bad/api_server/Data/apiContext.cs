using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_server;
using api_server.Model;

namespace api_server.Data
{
    public class apiContext : DbContext
    {
        public apiContext(DbContextOptions<apiContext> options)
            : base(options)
        {

        }

        public DbSet<api_server.Product> Products { get; set; }

        public DbSet<api_server.Order> Orders { get; set; }

        public DbSet<api_server.User> Users { get; set; }
        
        public DbSet<api_server.OrderLineItem> OrderLineItems { get; set; }


        protected override void OnModelCreating(ModelBuilder m)
        {

            m.Entity<OrderLineItem>().HasData(new api_server.OrderLineItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 }); 
            
            
            m.Entity<OrderLineItem>().HasData(new api_server.OrderLineItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1 });

            m.Entity<User>().HasData(new api_server.User
            {
                Id = 1,
                Name = "Lee",
                Email = "lee.fowler@ruralsourcing.com"
            });


            m.Entity<User>().HasData(new api_server.User
            {
                Id = 2,
                Name = "Lee test",
                Email = "lee.fowler+test@ruralsourcing.com"
            });

            m.Entity<Product>().HasData(new api_server.Product
            {
                Id = 1,
                Name = "Cat: Sebastian",
                Description = "Licky Cat",
                Color = "Black",
                Inventory = 1,
                Cost = 1000
            });

            m.Entity<Product>().HasData(new api_server.Product
            {
                Id = 2,
                Name = "Cat: Gilgamesh",
                Description = "Bitey Cat",
                Color = "Black",
                Inventory = 1,
                Cost = 1001
            });


            m.Entity<Product>().HasData(new api_server.Product
            {
                Id = 3,
                Name = "Cat: Random",
                Description = "Rando Cat",
                Color = "Black",
                Inventory = 50,
                Cost = 10
            });


            m.Entity<Order>().HasData(
                new api_server.Order
                {
                    Id = 1,
                    Date = DateTime.Now,
                    UserId = 1
                });

            m.Entity<Order>().HasData(

                new api_server.Order
                {

                    Id = 2
                    , Date=DateTime.Now
                    , UserId = 2


                }


                );

        }


    }
}
