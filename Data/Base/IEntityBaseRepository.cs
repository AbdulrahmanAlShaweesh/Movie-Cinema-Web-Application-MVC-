using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() 
    {
        Task<List<T>> GetAllAysnc();
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(int id, T Entity);
        Task<bool> DeleteAsync(int id);  
    }
}


/*
    public interface IEntityBaseRepository<T> where T : class, IEnityBase, new() {
        Task<T> 
    }
*/