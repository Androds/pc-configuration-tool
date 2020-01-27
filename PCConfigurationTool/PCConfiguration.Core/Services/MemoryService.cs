using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace PCConfiguration.Core.Services
{
    public class MemoryService : IService<IRepository<Memory>, Memory>
    {
        public IRepository<Memory> Repository { get; set; }
        public MemoryService(IRepository<Memory> repository)
        {
            this.Repository = repository;
        }

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

        public void Create(Memory memory)
        {
            if(this.Repository != null)
            {
                this.Repository.Create(memory);
            }
        }

        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Memory>>(null);
        }

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
