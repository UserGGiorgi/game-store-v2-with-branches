using GameStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly GameStoreDbContext _context;

        public GenericRepository(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
        public async Task<TEntity?> GetByIdAsync(Guid id) => await _context.Set<TEntity>().FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
        public async Task<bool> ExistsAsync(Guid id) => await _context.Set<TEntity>().AnyAsync(e => EF.Property<Guid>(e, "Id") == id);
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().AnyAsync(predicate);
        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

    }
}
