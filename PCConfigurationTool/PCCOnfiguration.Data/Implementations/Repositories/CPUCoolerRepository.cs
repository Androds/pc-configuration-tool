using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class CPUCoolerRepository : IRepository<CPUCooler>
    {
        private PcDbContext _context = null;
                
        public CPUCoolerRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(CPUCooler cpuCooler)
        {
            if(cpuCooler != null && this._context != null)
            {
                this._context.CPUCoolers.Add(cpuCooler);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<CPUCooler> GetAll()
        {
            if (_context != null)
            {
                return this._context.CPUCoolers.ToList();
            }

            return new List<CPUCooler>();
        }

        public async Task<IEnumerable<CPUCooler>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.CPUCoolers.ToListAsync();
            }

            return await Task.FromResult<IEnumerable<CPUCooler>>(null);
        }

        public async Task<CPUCooler> GetByIdAsync(int id)
        {
            if(id > 0 && this._context != null)
            {
                return await this._context.CPUCoolers.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<CPUCooler>(null);
        }
    }
}
