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
