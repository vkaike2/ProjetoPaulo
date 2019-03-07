using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjetoPaulo.Domain.Model;

namespace ProjetoPaulo.Service.Interface
{
    public interface IExemploService
    {
        Task<Exemplo> Cadastrar(Exemplo exemplo);
        Task<ICollection<Exemplo>> BuscarExemplos(string descricaoFiltro,int? skip, int? take);
        Task<Exemplo> BuscarExemploPorId(Guid id);
        Task<Exemplo> Alterar(Exemplo exemplo);
        Task Deletar(Exemplo exemplo);
    }
}
