using APItask1.Entities.Base;
using System.Linq.Expressions;

namespace APItask1.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
       
        Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T,bool>> expression=null,
            Expression<Func<T,object>>? orderExpression=null,
            bool isDescending = false,
            int skip = 0,
            int take = 0,
            bool isTracking = true,
            params string[] includes
            );
        Task<T> GetByIdAsync(int id);

        Task AddAsync (T entity);
        void Delete (T entity);
        void UpdateAsync (T entity);
        Task SaveChangesAsync();
    }
}
