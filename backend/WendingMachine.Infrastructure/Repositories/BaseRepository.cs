using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WendingMachine.Data.Entities;
using WendingMachine.Infrastructure.Interfaces;

namespace WendingMachine.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly WendingDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(WendingDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task DeleteById(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstAsync(obj => obj.Id == id);
        }

        public async Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter = null, string includeProperty = null, bool tracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperty))
                query = query.Include(includeProperty);
            if (!tracking)
                query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
