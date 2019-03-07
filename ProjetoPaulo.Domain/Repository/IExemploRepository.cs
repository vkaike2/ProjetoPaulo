using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjetoPaulo.Domain.Model;

namespace ProjetoPaulo.Domain.Repository
{
    public interface IExemploRepository : IRepositoryBase<Exemplo>
    {
        Task<ICollection<Exemplo>> ListaComPaginacaoEFiltro(string descricaoFiltro, int? skip, int? take);
    }
}
