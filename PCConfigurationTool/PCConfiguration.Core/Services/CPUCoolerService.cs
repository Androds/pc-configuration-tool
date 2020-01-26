using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CPUCoolerService : IService<IRepository<CPUCooler>, CPUCooler>
    {
        public IRepository<CPUCooler> Repository { get; set; }

        public CPUCoolerService(IRepository<CPUCooler> repository)
        {
            this.Repository = repository;
        }
        public void Create(CPUCooler cpuCooler)
        {
            if(cpuCooler != null && this.Repository != null)
            {
                this.Repository.Create(cpuCooler);
            }
        }

        public async Task<IEnumerable<CPUCooler>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<CPUCooler>>(null);
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

        public async Task<CPUCooler> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<CPUCooler>(null);
        }
    }
}
