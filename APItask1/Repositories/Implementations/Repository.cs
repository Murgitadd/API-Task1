using APItask1.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APItask1.Repositories.Implementations
{
    public class Repository <T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbSet<T> _table;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, params string[] includes)
        {
            var query= _table.AsQueryable();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
           T entity = await _table.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _table.Update(entity);
        }
    }
}
