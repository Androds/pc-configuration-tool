using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CPUService : IService<IRepository<CPU>, CPU>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<CPU> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CPUService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CPUService(IRepository<CPU> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Creates the <see cref="CPU"/>.
        /// </summary>
        /// <param name="cpu">The cpu.</param>
        public void Create(CPU cpu)
        {
            if(cpu != null && this.Repository != null)
            {
                this.Repository.Create(cpu);
            }
        }

        /// <summary>
        /// Gets all CPUs asynchronously.
        /// </summary>
        /// <returns>Collection of <see cref="CPU"/></returns>
        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<CPU>>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="CPU"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price the <see cref="CPU"/></returns>
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
        /// Gets the <see cref="CPU"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of the <see cref="CPU"/></returns>
        public async Task<CPU> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<CPU>(null);
        }
    }
}
