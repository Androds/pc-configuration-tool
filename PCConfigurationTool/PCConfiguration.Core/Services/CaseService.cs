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

        public void Create(Case compCase)
        {
            if(compCase != null && this.Repository != null)
            {
                this.Repository.Create(compCase);
            }
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            if(this.Repository != null)
            {
                return await this.Repository.GetAllAsync();
            }

            return await Task.FromResult<IEnumerable<Case>>(null);
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            if(id > 0 && this.Repository != null)
            {
                return await this.Repository.GetByIdAsync(id);
            }

            return await Task.FromResult<Case>(null);
        }

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
