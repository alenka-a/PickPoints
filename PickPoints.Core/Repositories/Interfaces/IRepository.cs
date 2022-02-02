using PickPoints.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PickPoints.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<T> FirstOrDefaultdAsync(Expression<Func<T, bool>> expression);

        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> expression);

        void AddAsync(T entity);

        void UpdateAsync(T entity);

        Task SaveAsync();
    }
}
