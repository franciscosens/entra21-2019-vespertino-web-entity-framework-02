using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private SistemaContext context;

        public ContatoRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Contato contato)
        {
            contato.RegistroAtivo = true;
            context.Contatos.Update(contato);
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var contato = context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contato == null)
                return false;

            contato.RegistroAtivo = false;
            return context.SaveChanges() == 1;
        }

        public int Inserir(Contato contato)
        {
            contato.RegistroAtivo = true;
            context.Contatos.Add(contato);
            context.SaveChanges();
            return contato.Id;
        }

        public Contato ObterPeloId(int id)
        {
            return context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<Contato> ObterTodosPeloIdCliente(int idCliente)
        {
            return context.Contatos
                .Where(x => x.RegistroAtivo && x.IdCliente == idCliente)
                .ToList();
        }
    }
}
