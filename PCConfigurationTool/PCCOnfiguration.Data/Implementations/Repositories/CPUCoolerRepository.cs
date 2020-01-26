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
    public class CPUCoolerRepository : IRepository<CPUCooler>
    {
        private PcDbContext _context = null;
                
        public CPUCoolerRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(CPUCooler obj)
        {
            this._context.CPUCoolers.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<CPUCooler> GetAll()
        {
            return this._context.CPUCoolers.ToList();
        }

        public async Task<IEnumerable<CPUCooler>> GetAllAsync()
        {
            return await this._context.CPUCoolers.ToListAsync();
        }

        public async Task<CPUCooler> GetByIdAsync(int id)
        {
            return await this._context.CPUCoolers.Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
