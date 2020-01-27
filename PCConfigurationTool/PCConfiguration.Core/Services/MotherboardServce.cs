using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class MotherboardService : IService<IRepository<Motherboard>, Motherboard>
    {
        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<Motherboard> Repository { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MotherboardService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public MotherboardService(IRepository<Motherboard> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Creates the specified <see cref="Motherboard"/>.
        /// </summary>
        /// <param name="motherboard">The motherboard.</param>
        public void Create(Motherboard motherboard)
        {
            if(this.Repository != null)
            {
                this.Repository.Create(motherboard);
            }
        }

        /// <summary>
        /// Gets all motherboards asynchronously.
        /// </summary>
        /// <returns>a new instance of the <see cref="Motherboard"/></returns>
        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Motherboard>>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="Motherboard"/> by given quantity.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Motherboard"/></returns>
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
        /// Gets the <see cref="Motherboard"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An instance of the <see cref="Motherboard"/></returns>
        public async Task<Motherboard> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Motherboard>(null);
        }
    }
}
