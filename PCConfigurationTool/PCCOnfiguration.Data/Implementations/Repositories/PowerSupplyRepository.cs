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
        public void Create(PowerSupply obj)
        {
            this._context.PowerSupplies.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<PowerSupply> GetAll()
        {
            return this._context.PowerSupplies.Include(p => p.FormFactor).ToList();
        }

        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            return await this._context.PowerSupplies.Include(p => p.FormFactor).ToListAsync();
        }
    }
}
