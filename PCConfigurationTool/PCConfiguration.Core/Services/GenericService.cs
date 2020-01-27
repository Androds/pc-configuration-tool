using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TRepository, TEntity>
        where TRepository: IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericService(TRepository repository)
        {
            this.Repository = repository; //?? throw new ArgumentNullException(nameof(repository));
        }
        public TRepository Repository { get;set; }

        public void Create(TEntity obj)
        {
           this.Repository.Create(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        /// <summary>
        /// Gets the <see cref="Case"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the case.</param>
        /// <returns>An instance of the <see cref="Case"/></returns>
        public async Task<TEntity> GetByIdAsync(int id)
        {
            if (id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<TEntity>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="Case"/> by the given quantity.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Case"/></returns>
        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            if (id > 0 && quantity > 0)
            {
                var compCase = await this.GetByIdAsync(id);
                var totalPrice = compCase.Price * quantity;
                return totalPrice;
            }

            return await Task.FromResult<decimal>(0);
        }
    }
}
