using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {
        int Inserir(Cliente cliente);

        bool Alterar(Cliente cliente);

        bool Apagar(int id);

        List<Cliente> ObterTodos(string busca);

        Cliente ObterPeloId(int id);
    }
}