using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPaulo.Domain.Repository
{
    public interface IUnitOfWork
    {
        IExemploRepository ExemploRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
