using PCConfiguration.Core.Interfaces;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Core.Services
{
    public class CaseService : IService<IRepository<Case>, Case>
    {
        public CaseService(IRepository<Case> repository)
        {
            this.Repository = repository;
        }
        public IRepository<Case> Repository { get; set; }

        public void Create(Case obj)
        {
            this.Repository.Create(obj);
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            return await this.Repository.GetAllAsync();
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            return await this.Repository.GetByIdAsync(id);
        }

        public async Task<decimal> CalculatePrice(int caseId, int quantity)
        {
            var compCase = await this.GetByIdAsync(caseId);
            var totalPrice = compCase.Price * quantity;
            return totalPrice;
        }
    }
}
