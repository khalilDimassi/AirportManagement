using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class unitofwork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Type _repositryType;
        private bool disposedValue; 

        public int Save()
        {
            return _context.SaveChanges();
        }

        public unitofwork(DbContext context, Type repositryType)
        {
            _context = context;
            _repositryType = repositryType;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return (IGenericRepository<T>) Activator.CreateInstance(_repositryType.MakeGenericType(typeof(T)), _context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        ~unitofwork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
