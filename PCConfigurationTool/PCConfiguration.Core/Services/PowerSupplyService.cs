using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class PowerSupplyService : IService<IRepository<PowerSupply>, PowerSupply>
    {
        public IRepository<PowerSupply> Repository { get; set; }

        public PowerSupplyService(IRepository<PowerSupply> repository)
        {
            this.Repository = repository;
        }
        public void Create(PowerSupply powerSupply)
        {
            if(powerSupply != null && this.Repository != null)
            {
                this.Repository.Create(powerSupply);
            }
        }

        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<PowerSupply>>(null);
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
