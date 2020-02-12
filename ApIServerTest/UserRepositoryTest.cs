using System;
using api_server_new.Repository;
using ApiServer;
using ApiServer.DataAccess.SQL;
using ApiServer.DataAccess.SQL.Repository;
using ApiServer.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;
public class UserRepositoryTests
{
    [Fact]
    public void Add_Cat()
    {
        IUserRepository sut = GetInMemoryUserRepository();
        User User = new User()
        {
            Id = 1
        };

        
        User savedUser = sut.Add(User).Result;

        Assert.Equal(1, sut.GetAll().Result.Count);
       
    }

    private static IUserRepository GetInMemoryUserRepository()
    {
        DbContextOptions<ApiContext> options;
        var builder = new DbContextOptionsBuilder<ApiContext>();

        builder.UseInMemoryDatabase("ApiContext");
        options = builder.Options;
        ApiContext UserDataContext = new ApiContext(options);

        UserDataContext.Database.EnsureDeleted();
        UserDataContext.Database.EnsureCreated();
        return new UserRepository(UserDataContext);
    }
}