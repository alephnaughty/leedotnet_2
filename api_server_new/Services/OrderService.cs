using ApiServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer;
using Microsoft.Extensions.Logging;
using ApiServer.Model;
using Microsoft.AspNetCore.Mvc;

namespace api_server_new.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(int id);
        Task<ActionResult<IEnumerable<Order>>> GetAll();
        Task<ActionResult<Order>> Get(int id);
        Task Update(Order ent);
        Task Add(Order ent);
        Task<ActionResult<Order>> Delete(int id);
    }
  
    public class OrderService : IOrderService
    { 
        private readonly IOrderRepository _orderRepository;
        
        // private readonly ILogger<OrderService> _logger;


        public OrderService(IOrderRepository repo) 
        {
            _orderRepository = repo;
            


        }
        public async Task<Order> GetProduct(int id)
        {
            return await _orderRepository.Get(id);
        }

        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<ActionResult<Order>> Get(int id)
        {
            return await _orderRepository.Get(id);
        }

        public async Task Update(Order ent)
        {
            await _orderRepository.Update(ent);
        }

        public async Task Add(Order ent)
        {
            await _orderRepository.Add(ent);
        }

        public async Task<ActionResult<Order>> Delete(int id)
        {
            return await _orderRepository.Delete(id);
        }

        public async Task<Order> AddToOrder(int OrderId, int ProductId, int Quantity)
        {

            
            var order = await this._orderRepository.Get(OrderId);
            //var orderLineItem =_liRepo.Add(new OrderLineItem(ProductId = ProductId, OrderId = OrderId, Quantity = Quantity));

            //var orderLineItem = await this._liRepo.Add();
            return order;
        }

        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
