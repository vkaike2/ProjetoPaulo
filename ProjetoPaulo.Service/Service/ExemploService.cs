using ProjetoPaulo.Domain.Model;
using ProjetoPaulo.Domain.Repository;
using ProjetoPaulo.Domain.Service;
using System;
using System.Collections.Generic;
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

        public async Task<Exemplo> Alterar(Exemplo exemplo)
        {
            await ValidarNovoExemplo(exemplo);

            bool jaExisteCadastrado = await _unitOfWork.ExemploRepository
                .ObterUmAsync(e => e.Descricao.Equals(exemplo.Descricao) && e.Id != exemplo.Id) != null;
            if (jaExisteCadastrado)
                throw new Exception("Ja existe um Exemplo Cadastrado pra essa descricao");

            var exemploCadastrado = await BuscarExemploPorId(exemplo.Id);
            exemploCadastrado.Descricao = exemplo.Descricao;

            _unitOfWork.ExemploRepository.Atualizar(exemploCadastrado);
            await _unitOfWork.CommitAsync();

            return exemploCadastrado;
        }

        public async Task<Exemplo> BuscarExemploPorId(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Envie um Id Valido Para Buscar");

            var exemplo = await _unitOfWork.ExemploRepository.ObterUmAsync(e => e.Id == id);

            if(exemplo is null)
                throw new Exception("Nao existe exemplo cadastrado para este ID");

            return exemplo;
        }

        public async Task<ICollection<Exemplo>> BuscarExemplos(string descricaoFiltro, int? skip, int? take)
        {
            if (string.IsNullOrEmpty(descricaoFiltro))
            {
                return await _unitOfWork.ExemploRepository.ObterAsync(e => true);
            }
            else
            {
                if (skip != null && take != null)
                {
                    return await _unitOfWork.ExemploRepository.ListaComPaginacaoEFiltro(descricaoFiltro, skip, take);
                }
                else
                {
                    return await _unitOfWork.ExemploRepository.ObterAsync(e => e.Descricao.Contains(descricaoFiltro));
                }
            }

        }

        public async Task<Exemplo> Cadastrar(Exemplo exemplo)
        {
            exemplo.Id = Guid.NewGuid();
            await ValidarNovoExemplo(exemplo);
            bool jaExisteCadastrado = await _unitOfWork.ExemploRepository.ObterUmAsync(e => e.Descricao.Equals(exemplo.Descricao)) != null;
            if (jaExisteCadastrado)
                throw new Exception("Ja existe um Exemplo Cadastrado pra essa descricao");

            await _unitOfWork.ExemploRepository.SalvarAsync(exemplo);
            await _unitOfWork.CommitAsync();

            return exemplo;
        }

        public async Task Deletar(Exemplo exemplo)
        {
            await BuscarExemploPorId(exemplo.Id);
            _unitOfWork.ExemploRepository.Remover(e => e.Id == exemplo.Id);
            await _unitOfWork.CommitAsync();
        }

        private async Task ValidarNovoExemplo(Exemplo exemplo)
        {
            if (string.IsNullOrEmpty(exemplo.Descricao))
                throw new Exception("A descrição do Exemplo nao pode ser vazia ou nula");
            if (exemplo.Descricao.Length > 20)
                throw new Exception($"a Descricao {exemplo.Descricao} nao pode ter mais do que 20 caracteres");
        }
    }
}
