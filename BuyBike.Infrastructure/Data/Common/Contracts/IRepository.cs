namespace PrintingHouse.Infrastructure.Data.Common.Contracts
{
    using System.Linq.Expressions;

    /// <summary>
    /// Abstraction of repository access methods
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// All records in a table
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>() where T : class;

        /// <summary>
        /// All records in a table
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="search">Expression for filtering result</param>
        /// <returns>Queryable expression tree</returns>
        IQueryable<T> All<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>() where T : class;

        /// <summary>
        /// The result collection won't be tracked by the context
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="search">Expression for filtering result</param>
        /// <returns>Expression tree</returns>
        IQueryable<T> AllReadonly<T>(Expression<Func<T, bool>> search) where T : class;

        /// <summary>
        /// Gets specific record from database by primary key
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">record identificator</param>
        /// <returns>Single record</returns>
        Task<T?> GetByIdAsync<T>(object? id) where T : class;

        /// <summary>
        /// Gets specific record from database by composed primary key
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">Object array of identificators</param>
        /// <returns>Single record (nullable)</returns>
        Task<T?> GetByIdsAsync<T>(object[] id) where T : class;

        /// <summary>
        /// Adds entity to the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity to add</param>
        Task AddAsync<T>(T entity) where T : class;

        /// <summary>
        /// Ads collection of entities to the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entities">Enumerable list of entities</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Updates a record in database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity for record to be updated</param>
        void Update<T>(T entity) where T : class;

        /// <summary>
        /// Updates set of records in the database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entities">Enumerable collection of entities to be updated</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="id">Identificator of record to be deleted</param>
        Task DeleteAsync<T>(object id) where T : class;

        /// <summary>
        /// Deletes a record from database
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity representing record to be deleted</param>
        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(IEnumerable<T> entities) where T : class;
        void DeleteRange<T>(Expression<Func<T, bool>> deleteWhereClause) where T : class;


        /// <summary>
        /// Detaches given entity from the context
        /// </summary>
        /// <typeparam name="T">Generic parameter of type class
        /// representing data table</typeparam>
        /// <param name="entity">Entity to be detached</param>
        void Detach<T>(T entity) where T : class;

        /// <summary>
        /// Saves all made changes in trasaction
        /// </summary>
        /// <returns>Error code</returns>
        Task<int> SaveChangesAsync();
    }
}