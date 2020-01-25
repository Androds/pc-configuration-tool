using System;
using System.Collections.Generic;
using System.Text;

namespace PCConfiguration.Data.Interfaces.Repositories
{
    public interface IGenericRepository <T> where T: class
    {
        IEnumerable<T> GetAll();
        void Create(T obj);
    }
}
