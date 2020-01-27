using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity: class
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>Collection of entities</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="obj">The entity.</param>
        void Create(TEntity obj);

        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets the entity by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetByIdAsync(int id);
    }
}
