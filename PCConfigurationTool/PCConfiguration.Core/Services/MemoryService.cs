using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class MemoryService : IService<IRepository<Memory>, Memory>
    { 
        
        public MemoryService(IRepository<Memory> repository)
        {
        this.Repository = repository;
        }
        public IRepository<Memory> Repository { get; set; }

        public async Task<decimal> CalculatePrice(int id, int quantity)
        {
            var entity = await this.GetByIdAsync(id);
            var totalPrice = entity.Price * quantity;
            return totalPrice;
        }

        public void Create(Memory obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<Memory>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public async Task<Memory> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }
    }
}
