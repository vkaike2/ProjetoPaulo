using ProjetoPaulo.Domain.Model;
using ProjetoPaulo.Domain.Repository;
using ProjetoPaulo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPaulo.Service.Service
{
    public class ExemploService : IExemploService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExemploService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Cadastrar(Exemplo exemplo)
        {
            await _unitOfWork.ExemploRepository.SalvarAsync(exemplo);
            await _unitOfWork.CommitAsync();
        }
    }
}
