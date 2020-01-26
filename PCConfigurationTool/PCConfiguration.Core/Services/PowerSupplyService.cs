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
        public void Create(PowerSupply obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            var entity = await this.GetByIdAsync(id);
            var totalPrice = entity.Price * quantity;
            return totalPrice;
        }

        public async Task<PowerSupply> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }
    }
}
