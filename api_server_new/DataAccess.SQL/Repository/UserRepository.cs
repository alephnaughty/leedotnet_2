using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer;
using ApiServer.DataAccess.SQL;
using ApiServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace api_server_new.Repository
{
    public interface IUserRepository
    {
        Task<User> Add(User entity);
        Task<User> Delete(int id);
        Task<User> Get(int id);
        Task<List<User>> GetAll();
        Task<User> Update(User entity);
    }

    public class UserRepository : IUserRepository
    {

        private ApiContext _ctx;

        public UserRepository(ApiContext ctx)
        { 
            this._ctx = ctx;

        }
        public async Task<User> Add(User entity)
        {
            _ctx.Set<User>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(int id)
        {
            var entity = await _ctx.Set<User>().FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _ctx.Set<User>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Get(int id)
        {
            return await _ctx.Set<User>().FindAsync(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _ctx.Set<User>().ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }
      

    }

}
