namespace PrintingHouse.Infrastructure.Data.Common
{
    using System.Linq.Expressions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    using Contracts;
    using BuyBike.Infrastructure.Data;

    /// <summary>
    /// Implementation of repository access methods
    /// for Relational Database Engine with generic methods
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Entity framework DB context holding connection information and properties
        /// and tracking entity states 
        /// </summary>
        protected DbContext Context { get; set; }

        /// <summary>
        /// Representation of table in database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <returns></returns>
        protected DbSet<T> DbSet<T>() where T : class
        {
            return Context.Set<T>();
        }

        public Repository(BuyBikeDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity to add</param>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entities">Enumerable list of entities</param>
        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <returns>Queryable expression tree</returns>
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>().Where(search);
        }

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <returns>Expression tree</returns>
        public IQueryable<T> AllReadonly<T>() where T : class
        {
            return DbSet<T>()
                .AsNoTracking();
        }
        public IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class
        {
            return DbSet<T>()
                .Where(search)
                .AsNoTracking();
        }

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">Identificator of record to be deleted</param>
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            Delete(entity);
        }

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity representing record to be deleted</param>
        public void Delete<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity to be detached</param>
        public void Detach<T>(T entity) where T : class
        {
            EntityEntry entry = Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        /// <summary>
        /// Disposing the context when it is not neede
        /// Don't have to call this method explicitely
        /// Leave it to the IoC container
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">record identificator</param>
        /// <returns>Single record (nullable)</returns>
        public async Task<T?> GetByIdAsync<T>(object? id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// Gets specific record from database by composed primary key
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">Object array of identificators</param>
        /// <returns>Single record (nullable)</returns>
        public async Task<T?> GetByIdsAsync<T>(object[] id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity for record to be updated</param>
        public void Update<T>(T entity) where T : class
        {
            DbSet<T>().Update(entity);
        }

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().UpdateRange(entities);
        }

        /// <summary>
        /// Remove set of records from the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entities">Enumerable collection of entities to be removed</param>
        public void DeleteRange<T>(IEnumerable<T> entities) where T : class
        {
            DbSet<T>().RemoveRange(entities);
        }

        /// <summary>
        /// Remove set of records from the database with Where clause
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="deleteWhereClause">Delegate function as lambda expression to filter result</param>
        public void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class
        {
            var entities = All(deleteWhereClause);
            DeleteRange(entities);
        }
    }
}