using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IContatoRepository
    {
        int Inserir(Contato contato);

        bool Alterar(Contato contato);

        List<Contato> ObterTodosPeloIdCliente(int idCliente);

        Contato ObterPeloId(int id);

        bool Apagar(int id);

    }
}