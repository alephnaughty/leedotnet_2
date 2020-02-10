using api_server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server;
using Microsoft.Extensions.Logging;
using api_server.Model;
using api_server_new.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_server_new.Services
{
    public interface IUserService
    {
        Task<User> GetUser(int id);
        Task<ActionResult<IEnumerable<User>>> GetAll();
        Task<ActionResult<User>> Get(int id);
        Task Update(User ent);
        Task Add(User ent);
        Task<ActionResult<User>> Delete(int id);
    }

    public class UserService : IUserService
    { 
        private readonly IUserRepository _userRepository;
        //private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repo)
        {
            _userRepository = repo;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<ActionResult<User>> Get(int id)
        {
            return await _userRepository.Get(id);
        }

        public async Task Update(User ent)
        {
            await _userRepository.Update(ent);
        }

        public async Task Add(User ent)
        {
            await _userRepository.Add(ent);
        }

        public async Task<ActionResult<User>> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

    }
}
