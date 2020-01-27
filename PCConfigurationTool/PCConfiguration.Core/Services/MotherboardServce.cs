using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class MotherboardService : IService<IRepository<Motherboard>, Motherboard>
    {
        public IRepository<Motherboard> Repository { get; set; }

        public MotherboardService(IRepository<Motherboard> repository)
        {
            this.Repository = repository;
        }
        public void Create(Motherboard motherboard)
        {
            if(this.Repository != null)
            {
                this.Repository.Create(motherboard);
            }
        }

        public async Task<IEnumerable<Motherboard>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Motherboard>>(null);
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
