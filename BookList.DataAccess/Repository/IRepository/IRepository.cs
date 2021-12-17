using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookList.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);

        Task<IEnumerable<T>> FindAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,
            bool isTracking = true
            );

        T FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null,
            bool isTracking = true
            );

        void Add(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

        void Save();
    }
}
