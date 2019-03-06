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
    }
}
