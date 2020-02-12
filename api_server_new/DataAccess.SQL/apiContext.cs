using System;
using ApiServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiServer.DataAccess.SQL
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }
        
        public DbSet<OrderLineItem> OrderLineItems { get; set; }


        protected override void OnModelCreating(ModelBuilder m)


        {


           



            m.Entity<Order>().Property(o => o.Status).HasConversion(new EnumToStringConverter<OrderStatus>());
            m.Entity<OrderLineItem>().HasData(new OrderLineItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 }); 
            
            
            m.Entity<OrderLineItem>().HasData(new OrderLineItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1 });

            m.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Lee",
                Email = "lee.fowler@ruralsourcing.com"
            });


            m.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Lee test",
                Email = "lee.fowler+test@ruralsourcing.com"
            });

            m.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Cat: Sebastian",
                Description = "Licky Cat",
                Color = "Black",
                Inventory = 1,
                Cost = 1000
            });

            m.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Cat: Gilgamesh",
                Description = "Bitey Cat",
                Color = "Black",
                Inventory = 1,
                Cost = 1001
            });


            m.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Cat: Random",
                Description = "Rando Cat",
                Color = "Black",
                Inventory = 50,
                Cost = 10
            });


            m.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Date = DateTime.Now,
                    UserId = 1
                });

            m.Entity<Order>().HasData(

                new Order
                {

                    Id = 2
                    , Date=DateTime.Now
                    , UserId = 2


                }


                );

        }


    }
}
