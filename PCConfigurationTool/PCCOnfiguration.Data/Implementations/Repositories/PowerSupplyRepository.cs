using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using PCConfiguration.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class PowerSupplyRepository : IRepository<PowerSupply>
    {
        private PcDbContext _context = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerSupplyRepository"/> class.
        /// </summary>
        /// <param name="_context">The context.</param>
        public PowerSupplyRepository(PcDbContext _context)
        {
            this._context = _context;
        }

        /// <inheritdoc/>
        public void Create(PowerSupply powerSupply)
        {
            if (powerSupply != null && this._context != null)
            {
                this._context.PowerSupplies.Add(powerSupply);
                this._context.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<PowerSupply> GetAll()
        {
            if(this._context != null)
            {
                return this._context.PowerSupplies.Include(p => p.FormFactor).AsNoTracking().ToList();
            }

            return new List<PowerSupply>();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PowerSupply>> GetAllAsync()
        {
            if(this._context != null)
            {
                return await this._context.PowerSupplies.Include(p => p.FormFactor).AsNoTracking().ToListAsync();
            }

            return await Task.FromResult<IEnumerable<PowerSupply>>(null);
        }

        /// <inheritdoc/>
        public async Task<PowerSupply> GetByIdAsync(int id)
        {
            if(id > 0 && this._context != null)
            {
                return await this._context.PowerSupplies.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }

            return await Task.FromResult<PowerSupply>(null);
        }
    }
}
