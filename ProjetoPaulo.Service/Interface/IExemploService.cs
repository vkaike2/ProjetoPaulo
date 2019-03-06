using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjetoPaulo.Domain.Model;

namespace ProjetoPaulo.Service.Interface
{
    public interface IExemploService
    {
        Task Cadastrar(Exemplo exemplo);
    }
}
