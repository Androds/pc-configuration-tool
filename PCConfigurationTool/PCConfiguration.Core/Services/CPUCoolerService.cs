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
        public void Create(CPUCooler obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<CPUCooler>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            var entity = await this.GetByIdAsync(id);
            var totalPrice = entity.Price * quantity;
            return totalPrice;
        }

        public async Task<CPUCooler> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }
    }
}
