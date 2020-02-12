using System;
using api_server_new.Repository;
using ApiServer;
using ApiServer.DataAccess.SQL;
using ApiServer.DataAccess.SQL.Repository;
using ApiServer.Repository;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
public class OrderRepositoryTests
{
    [Fact]
    public void Add_Cat()
    {   
        
        IOrderRepository sut = GetInMemoryOrderRepository();
        Order Order = new Order()
        {
            
        };

        
        Order savedOrder = sut.Add(Order).Result;

        Assert.Equal(1, sut.GetAll().Result.Count);
       
       
    }

    private static IOrderRepository GetInMemoryOrderRepository()
    {
        var logger = new NullLogger<OrderRepository>();
                     DbContextOptions <ApiContext> options;
        var builder = new DbContextOptionsBuilder<ApiContext>();

        builder.UseInMemoryDatabase("ApiContext");
        options = builder.Options;
        ApiContext OrderDataContext = new ApiContext(options);
        
        OrderDataContext.Database.EnsureDeleted();
        OrderDataContext.Database.EnsureCreated();
        return new OrderRepository(OrderDataContext, logger);
    }
}