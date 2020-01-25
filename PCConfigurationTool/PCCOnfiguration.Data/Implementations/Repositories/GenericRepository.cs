using Microsoft.EntityFrameworkCore;
using PCConfiguration.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfiguration.Data.Implementations.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        private PcDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {

        }
        public GenericRepository(PcDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Create(T obj)
        {
            table.Add(obj);
            this._context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
    }
}
