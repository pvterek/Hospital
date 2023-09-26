using Hospital.Utilities.UserInterface;
using NHibernate;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for common database operations, such as adding, deleting, updating, and retrieving entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to operate on.</typeparam>
    internal static class DatabaseOperations<TEntity> where TEntity : class
    {
        private delegate void DatabaseOperation(TEntity entity, ISession session);
        
        private static void ExecuteInTransaction(TEntity entity, ISession session, DatabaseOperation operation)
        {
            using var transaction = session.BeginTransaction();

            try
            {
                operation(entity, session);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                UiHelper.HandleError(ex);
            }
        }
        
        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Add(TEntity entity, ISession session)
        {
            ExecuteInTransaction(entity, session, (e, s) => s.Save(e));
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Delete(TEntity entity, ISession session)
        {
            ExecuteInTransaction(entity, session, (e, s) => s.Delete(e));
        }
        
        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Update(TEntity entity, ISession session)
        {
            ExecuteInTransaction(entity, session, (e, s) => s.Update(e));
        }
        

        /// <summary>
        /// Retrieves all entities of the specified type from the database.
        /// </summary>
        /// <param name="session">The database session to use for the operation.</param>
        /// <returns>A collection of all entities of the specified type.</returns>
        internal static IEnumerable<TEntity> GetAll(ISession session)
        {
            return session.Query<TEntity>().ToList();
        }
    }
}