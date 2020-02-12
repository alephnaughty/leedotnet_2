using ApiServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiServer;
using Microsoft.Extensions.Logging;
using ApiServer.Model;
using api_server_new.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_server_new.Services
{


    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        //private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repo) //: base(repo)
        {
            _productRepository = repo;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<ActionResult<Product>> Get(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task Update(Product ent)
        {
            await _productRepository.Update(ent);
        }

        public async Task Add(Product ent)
        {
            await _productRepository.Add(ent);
        }

        public async Task<ActionResult<Product>> Delete(int id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
