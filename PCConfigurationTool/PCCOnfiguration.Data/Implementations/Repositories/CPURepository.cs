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
    public class CPURepository : IRepository<CPU>
    {
        private PcDbContext _context = null;
                
        public CPURepository(PcDbContext _context)
        {   
            this._context = _context;
        }
        public void Create(CPU cpu)
        {
            if (_context != null && cpu != null)
            {
                this._context.CPUs.Add(cpu);
                this._context.SaveChanges();
            }
        }

        public IEnumerable<CPU> GetAll()
        {
            if(this._context != null)
            {
                return this._context.CPUs.ToList();
            }

            return new List<CPU>();
        }

        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.CPUs.ToListAsync();
            }

            return await Task.FromResult<IEnumerable<CPU>>(null);
        }

        public async Task<CPU> GetByIdAsync(int id)
        {
            if (this._context != null && id > 0)
            {
                return await this._context.CPUs.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<CPU>(null);
        }
    }
}
