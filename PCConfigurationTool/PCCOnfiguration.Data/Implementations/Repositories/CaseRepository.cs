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
    public class CaseRepository : IRepository<Case>
    {
        private PcDbContext _context = null;
                
        public CaseRepository(PcDbContext _context)
        {
            this._context = _context;
        }
        public void Create(Case compCase)
        {
            if(compCase != null && this._context != null) {
                this._context.Cases.Add(compCase);
                this._context.SaveChanges();
            }
            
        }

        public IEnumerable<Case> GetAll()
        {
            if (_context != null)
            {
                return this._context.Cases.Include(c => c.Type).ToList();
            }

            return new List<Case>();
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            if (_context != null)
            {
                return await this._context.Cases.Include(c => c.Type).ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Case>>(null);
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            if (id > 0 && this._context != null)
            {
                return await this._context.Cases.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            return await Task.FromResult<Case>(null);
        }
    }
}
