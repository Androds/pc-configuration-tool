using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class CaseRepository : IRepository<Case>
    {
        private PcDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CaseRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public CaseRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(Case compCase)
        {
            if(compCase != null && this._context != null) {
                this._context.Cases.Add(compCase);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<Case> GetAll()
        {
            if (_context != null)
            {
                return this._context.Cases.Include(c => c.Type).AsNoTracking().ToList();
            }

            return new List<Case>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Case>> GetAllAsync()
        {
            if (_context != null)
            {
                return await this._context.Cases.Include(c => c.Type).AsNoTracking().ToListAsync();
            }

            return await Task.FromResult<IEnumerable<Case>>(null);
        }

        /// <inheritdoc/>
        public async Task<Case> GetByIdAsync(int id)
        {
            if (id > 0 && this._context != null)
            {
                return await this._context.Cases.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }

            return await Task.FromResult<Case>(null);
        }
    }
}
