using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CaseService : IService<IRepository<Case>, Case>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaseService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CaseService(IRepository<Case> repository)
        {
            this.Repository = repository;
        }

        /// <summary>
        /// Gets or sets the repository used to execute the database operations.
        /// </summary>
        public IRepository<Case> Repository { get; set; }

        /// <summary>
        /// Creates the <see cref="Case"/>.
        /// </summary>
        /// <param name="compCase">The computer case.</param>
        public void Create(Case compCase)
        {
            if(compCase != null && this.Repository != null)
            {
                this.Repository.Create(compCase);
            }
        }

        /// <summary>
        /// Gets all computer cases asynchronously.
        /// </summary>
        /// <returns>Collection of <see cref="Case"/>.</returns>
        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Case>>(null);
        }

        /// <summary>
        /// Gets the <see cref="Case"/> by identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the case.</param>
        /// <returns>An instance of the <see cref="Case"/></returns>
        public async Task<Case> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Case>(null);
        }

        /// <summary>
        /// Calculates the price of the <see cref="Case"/> by the given quantity.
        /// </summary>
        /// <param name="caseId">The case identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>The price of the <see cref="Case"/></returns>
        public async Task<decimal> CalculatePrice(int caseId, int quantity)
        {
            if(caseId > 0 && quantity > 0)
            {
                var compCase = await this.GetByIdAsync(caseId);
                var totalPrice = compCase.Price * quantity;
                return totalPrice;
            }

            return await Task.FromResult<decimal>(0);
        }
    }
}
