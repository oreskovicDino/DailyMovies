namespace DailyMoviesDAL.Repositories
{
    using DailyMoviesDAL.DataAccess;
    using DailyMoviesDAL.Repositories.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContex contex;
        private readonly ILogger logger;
        protected DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContex contex, ILogger logger)
        {
            this.contex = contex;
            this.logger = logger;
            dbSet = contex.Set<T>();
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);

            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e, "{Type} \"All\" method error", typeof(T));
                return new List<T>();
            }
        }

        public virtual Task<bool> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);

        }

        public virtual async Task<bool> Upsert(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
