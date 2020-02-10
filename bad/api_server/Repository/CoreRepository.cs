using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_server.Model;
using Microsoft.EntityFrameworkCore;

namespace api_server.Repository
{
    public abstract class CoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _ctx;
        public CoreRepository(TContext context)
        {
            this._ctx = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _ctx.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _ctx.Set<TEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}