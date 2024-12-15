    using System;
    using System.Collections.Generic;
    using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    namespace CinemaMovieWebApplication.Data.Base
    {
        public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
        {
            private readonly MovieCinemaDbContext _context; 

            public EntityBaseRepository(MovieCinemaDbContext context)
            {   
                _context = context;
            }

            public async Task CreateAsync(T Entity) {
                await _context.Set<T>().AddAsync(Entity);
                await _context.SaveChangesAsync();
            }// create actor
           

            public async Task<List<T>> GetAllAysnc(params  Expression<Func<T, object>>[] includes) {
                IQueryable<T> query = _context.Set<T>();
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return await query.ToListAsync();
            }  // this to set the actor as a parameter
            

            public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            
            public async Task<bool> DeleteAsync(int id)
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null) return false;

                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }

            public async Task UpdateAsync(int id, T Entity)
            {
                EntityEntry entityEntry =  _context.Entry<T>(Entity);
                //set the state of the entity
                entityEntry.State =  EntityState.Modified;

                await _context.SaveChangesAsync();
            }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includePro)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includePro.Aggregate(query , (current , includePro) => current.Include(includePro));
            return await query.ToListAsync();   
        }
    }
}


