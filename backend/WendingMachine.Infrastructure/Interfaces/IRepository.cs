using System.Linq.Expressions;
using WendingMachine.Data.Entities;

namespace WendingMachine.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter = null, string includeProperty = null, bool tracking = true);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task DeleteById(int id);
        public Task Save();
    }
}
