    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            /*
                public class EnitityBaseRepoistory<T> : IEntityBaseRepository<T> where T : class, IEntity, new() {
                    private readonly ApplicationDbContext _context; 

                    pub EnitityBaseRepository(ApplicationDbContext context) {
                        _context = context;
                    }
                }
            */

            public async Task CreateAsync(T Entity) {
                await _context.Set<T>().AddAsync(Entity);
                await _context.SaveChangesAsync();
            }// create actor
           

            public async Task<List<T>> GetAllAysnc() =>  await _context.Set<T>().ToListAsync();   // this to set the actor as a parameter
            

            public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            
             public async Task<bool> DeleteAsync(int id)
            {
                var actor = await _context.Actors.FindAsync(id);
                if (actor == null) return false;

                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
                return true; // Return true if deletion was successful
            }

            public async Task UpdateAsync(int id, T Entity)
            {
                EntityEntry entityEntry =  _context.Entry<T>(Entity);
                //set the state of the entity
                entityEntry.State =  EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> DeleteActorAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null) return false;

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return true; // Return true if deletion was successful
        }
    }
}




