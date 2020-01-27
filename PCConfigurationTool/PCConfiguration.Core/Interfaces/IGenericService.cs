using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Interfaces
{
    public interface IGenericService<TRepository, TEntity> where TRepository: IGenericRepository<TEntity>
        where TEntity: class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Create(TEntity obj);

        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        TRepository Repository { get; set; }

        /// <summary>
        /// Gets the <see cref="Case"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the case.</param>
        /// <returns>An instance of the <see cref="Case"/></returns>
        Task<TEntity> GetByIdAsync(int id);


        /// <summary>
        /// Calculates the price of the <see cref="Case"/> by the given quantity.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Case"/></returns>
        Task<decimal> CalculatePrice(int id, int quantity);
    }
}
