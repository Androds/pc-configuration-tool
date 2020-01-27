using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class CPURepository : IRepository<CPU>
    {
        private PcDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CPURepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public CPURepository(PcDbContext _context)
        {   
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(CPU cpu)
        {
            if (_context != null && cpu != null)
            {
                this._context.CPUs.Add(cpu);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<CPU> GetAll()
        {
            if(this._context != null)
            {
                return this._context.CPUs.ToList();
            }

            return new List<CPU>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CPU>> GetAllAsync()
        {
            if (this._context != null)
            {
                return await this._context.CPUs.ToListAsync();
            }

            return await Task.FromResult<IEnumerable<CPU>>(null);
        }

        /// <inheritdoc/>
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
