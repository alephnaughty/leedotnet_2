using System;
using api_server_new.Repository;
using ApiServer;
using ApiServer.DataAccess.SQL;
using ApiServer.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;
public class ProductRepositoryTests
{
    [Fact]
    public void Add_Cat()
    {
        IProductRepository sut = GetInMemoryProductRepository();
        Product Product = new Product()
        {
            Id = 1,
            Name = "Cat",
            Description = "Cat Desc"
        };

        
        Product savedProduct = sut.Add(Product).Result;

        Assert.Equal(1, sut.GetAll().Result.Count);
        Assert.Equal("Cat", savedProduct.Name);
        Assert.Equal("Cat Desc", savedProduct.Description);
       
    }

    private static IProductRepository GetInMemoryProductRepository()
    {
        DbContextOptions<ApiContext> options;
        var builder = new DbContextOptionsBuilder<ApiContext>();

        builder.UseInMemoryDatabase("ApiContext");
        options = builder.Options;
        ApiContext ProductDataContext = new ApiContext(options);

        ProductDataContext.Database.EnsureDeleted();
        ProductDataContext.Database.EnsureCreated();
        return new ProductRepository(ProductDataContext);
    }
}