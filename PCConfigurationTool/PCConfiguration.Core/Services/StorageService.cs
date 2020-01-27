using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class StorageService : IService<IRepository<Storage>, Storage>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<Storage> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public StorageService(IRepository<Storage> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Creates the specified <see cref="Storage"/>.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public void Create(Storage storage)
        {
            if(storage != null)
            {
                this.Repository.Create(storage);
            }
        }

        /// <summary>
        /// Gets all storages asynchronously.
        /// </summary>
        /// <returns>An instance of the <see cref="Storage"/></returns>
        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Storage>>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="Storage"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Storage"/></returns>
        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            if(id > 0 && quantity > 0)
            {
                var entity = await this.GetByIdAsync(id);
                var totalPrice = entity.Price * quantity;
                return totalPrice;
            }

            return await Task.FromResult<decimal>(0);
        }

        /// <summary>
        /// Gets the <see cref="Storage"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of the <see cref="Storage"/></returns>
        public async Task<Storage> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Storage>(null);
        }
    }
}
