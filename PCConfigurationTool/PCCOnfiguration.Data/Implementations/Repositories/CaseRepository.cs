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
        public void Create(Case obj)
        {
            this._context.Cases.Add(obj);
            this._context.SaveChanges();
        }

        public IEnumerable<Case> GetAll()
        {
            return this._context.Cases.Include(c => c.Type).ToList();
        }

        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            return await this._context.Cases.Include(c => c.Type).ToListAsync();
        }

        public async Task<Case> GetByIdAsync(int id)
        {
            return await this._context.Cases.Where(c=> c.Id == id).FirstOrDefaultAsync();
        }
    }
}
