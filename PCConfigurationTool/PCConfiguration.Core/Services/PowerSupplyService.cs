using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class PowerSupplyService : IService<IRepository<PowerSupply>, PowerSupply>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<PowerSupply> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerSupplyService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PowerSupplyService(IRepository<PowerSupply> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Creates the specified <see cref="PowerSupply"/>.
        /// </summary>
        /// <param name="powerSupply">The power supply.</param>
        public void Create(PowerSupply powerSupply)
        {
            if(powerSupply != null && this.Repository != null)
            {
                this.Repository.Create(powerSupply);
            }
        }

        /// <summary>
        /// Gets all power supplies asynchronously.
        /// </summary>
        /// <returns>Collection of <see cref="PowerSupply"/></returns>
        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<PowerSupply>>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="PowerSupply"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="PowerSupply"/></returns>
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
        /// Gets the <see cref="PowerSupply"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of the <see cref="PowerSupply"/></returns>
        public async Task<PowerSupply> GetByIdAsync(int id)
        {
            if(id > 0)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<PowerSupply>(null);
        }
    }
}
