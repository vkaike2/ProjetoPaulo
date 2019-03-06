using ProjetoPaulo.Data.Context;
using ProjetoPaulo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPaulo.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PauloContext _context;

        private IExemploRepository _exemploRepository;

        public UnitOfWork(PauloContext context)
        {
            _context = context;
        }

        public IExemploRepository ExemploRepository
        {
            get
            {
                return _exemploRepository ?? (_exemploRepository = new ExemploRepository(_context));
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
