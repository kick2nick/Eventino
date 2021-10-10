using Dal.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dal
{
    public class GenericRepository<T> : IAsyncRepository<T> where T : class
    {
        protected EventinoDbContext _context;

        public GenericRepository(EventinoDbContext context)
        {
            _context = context;
        }

        public virtual Task<T> GetById(Guid id) => _context.Set<T>().FindAsync(id).AsTask();

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().FirstOrDefaultAsync(predicate);

        public virtual async Task Add(T entity)
        {
            // await Context.AddAsync(entity);
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual Task Update(T entity)
        {
            //_context.Set<T>().Update(entity);
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public virtual Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual Task<int> CountAll() => _context.Set<T>().CountAsync();

        public virtual Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);
    }
}
