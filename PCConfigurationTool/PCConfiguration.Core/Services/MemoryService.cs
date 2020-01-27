using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PCConfiguration.Core.Services
{
    public class MemoryService : IService<IRepository<Memory>, Memory>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<Memory> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MemoryService(IRepository<Memory> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Calculates the price of the <see cref="Memory"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Memory"/></returns>
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
        /// Creates the specified <see cref="Memory"/>.
        /// </summary>
        /// <param name="memory">The memory.</param>
        public void Create(Memory memory)
        {
            if(this.Repository != null)
            {
                this.Repository.Create(memory);
            }
        }

        /// <summary>
        /// Gets all memories asynchronously.
        /// </summary>
        /// <returns>Collection of the <see cref="Memory"/></returns>
        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Memory>>(null);
        }

        /// <summary>
        /// Gets the <see cref="Memory"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns> An instance of the <see cref="Memory"/></returns>
        public async Task<Memory> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Memory>(null);
        }
    }
}
