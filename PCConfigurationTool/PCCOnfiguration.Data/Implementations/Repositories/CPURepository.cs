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
        public void Create(CPU obj)
        {
            this._context.CPUs.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<CPU> GetAll()
        {
            return this._context.CPUs.ToList();
        }

        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            return await this._context.CPUs.ToListAsync();
        }
    }
}
