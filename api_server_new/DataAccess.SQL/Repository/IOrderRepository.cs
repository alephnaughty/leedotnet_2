using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Repository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order entity);
        Task<Order> Delete(int id);
        Task<Order> Get(int id);
        Task<List<Order>> GetAll();
        Task<Order> Update(Order entity);
        Task<Order> GetOrder(int id);
        Task<int> Save(Order order);
    }


    public interface IProductRepository
    {
        Task<Product> Add(Product entity);
        Task<Product> Delete(int id);
        Task<Product> Get(int id);
        Task<List<Product>> GetAll();
        Task<Product> Update(Product entity);
    }
}
