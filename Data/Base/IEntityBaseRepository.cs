using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() 
    {
        Task<List<T>> GetAllAysnc(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(int id, T Entity);
        Task<bool> DeleteAsync(int id);  
        Task<List<T>> GetAllAsync(params Expression<Func<T , Object>> [] includePro);
    }
}


 