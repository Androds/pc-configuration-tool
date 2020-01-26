using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class PowerSupplyRepository : IRepository<PowerSupply>
    {
        private PcDbContext _context = null;
                
        public PowerSupplyRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(PowerSupply powerSupply)
        {
            if (powerSupply != null && this._context != null)
            {
                this._context.PowerSupplies.Add(powerSupply);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<PowerSupply> GetAll()
        {
            if(this._context != null)
            {
                return this._context.PowerSupplies.Include(p => p.FormFactor).ToList();
            }

            return new List<PowerSupply>();
        }

        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            if(this._context != null)
            {
                return await this._context.PowerSupplies.Include(p => p.FormFactor).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<PowerSupply>>(null);
        }

        public async Task<PowerSupply> GetByIdAsync(int id)
        {
            if(id > 0 && this._context != null)
            {
                return await this._context.PowerSupplies.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<PowerSupply>(null);
        }
    }
}
