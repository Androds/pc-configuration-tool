using PCConfiguration.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Interfaces
{
    public interface IService<TRepository, TEntity> where TRepository: IRepository<TEntity>
        where TEntity: class
    {
        /// <summary>
        /// Calculates the price of the entity by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the entity</returns>
        Task<decimal> CalculatePrice(int id, int quantity);

        /// <summary>
        /// Gets all entities asynchronously.
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Gets the entity by identifier asynchronouslly.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetByIdAsync(int Id);

        void Create(TEntity obj);
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        TRepository Repository { get; set; }
    }
}
