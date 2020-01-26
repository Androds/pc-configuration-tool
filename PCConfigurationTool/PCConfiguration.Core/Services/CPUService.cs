using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CPUService : IService<IRepository<CPU>, CPU>
    {
        public IRepository<CPU> Repository { get; set; }

        public CPUService(IRepository<CPU> repository)
        {
            this.Repository = repository;
        }
        public void Create(CPU cpu)
        {
            if(cpu != null && this.Repository != null)
            {
                this.Repository.Create(cpu);
            }
        }

        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<CPU>>(null);
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
