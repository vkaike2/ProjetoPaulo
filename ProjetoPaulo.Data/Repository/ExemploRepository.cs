using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProjetoPaulo.Data.Context;
using ProjetoPaulo.Data.Entity;
using ProjetoPaulo.Domain.Repository;
using DomainModel = ProjetoPaulo.Domain.Model;


namespace ProjetoPaulo.Data.Repository
{
    public class ExemploRepository : RepositoryBase<DomainModel.Exemplo, Exemplo>, IExemploRepository
    {
        public ExemploRepository(PauloContext context) : base(context)
        {

        }

        public async Task<ICollection<DomainModel.Exemplo>> ListaComPaginacaoEFiltro(string descricaoFiltro, int? skip, int? take)
        {
            return await _db.Exemplo
                .ProjectTo<DomainModel.Exemplo>(_mapper.ConfigurationProvider)
                .Where(e => e.Descricao.Contains(descricaoFiltro))
                .Skip(skip.Value).Take(take.Value).ToListAsync();
        }
    }
}
