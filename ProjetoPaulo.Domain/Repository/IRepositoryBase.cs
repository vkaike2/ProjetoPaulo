using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjetoPaulo.Domain.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> ObterAsync(Expression<Func<T, bool>> where);
        Task<T> ObterUmAsync(Expression<Func<T, bool>> where);
        Task SalvarAsync(ICollection<T> commands);
        Task SalvarAsync(T command);
        void Atualizar(T command);
        void Remover(Expression<Func<T, bool>> where);
    }
}
