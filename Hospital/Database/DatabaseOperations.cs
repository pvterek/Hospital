using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using Hospital.Objects.PatientObject;
using NHibernate;

namespace Hospital.Database
{
    /// <summary>
    /// Utility class for common database operations, such as adding, deleting, updating, and retrieving entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to operate on.</typeparam>
    internal static class DatabaseOperations<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Add(TEntity entity, ISession session)
        {
            using var transaction = session.BeginTransaction();

            try
            {
                session.Save(entity);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            } 
        }

        /// <summary>
        /// Deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Delete(TEntity entity, ISession session)
        {
            using var transaction = session.BeginTransaction();

            session.Delete(entity);

            transaction.Commit();
        }

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <param name="session">The database session to use for the operation.</param>
        internal static void Update(TEntity entity, ISession session)
        {
            using var transaction = session.BeginTransaction();

            try
            {
                session.Update(entity);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
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