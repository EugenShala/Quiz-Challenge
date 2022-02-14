using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDemo.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Find(int id);
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true
            );

        Task<T> FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true
        );

        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task Save();
    }
}
