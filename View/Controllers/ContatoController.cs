using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Interfaces;
using Repository.Repositories;

namespace View.Controllers
{
    [Route("contato")]
    public class ContatoController : Controller
    {
        private IContatoRepository repository;

        public ContatoController(IContatoRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var contato = repository.ObterPeloId(id);
            if (contato == null)
                return NotFound();

            return Json(contato);
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Contato contato)
        {
            var alterou = repository.Alterar(contato);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        [HttpPost, Route("inserir")]
        public ActionResult Inserir(Contato contato)
        {
            var id = repository.Inserir(contato);
            var resultado = new { id = id };
            return Json(resultado);
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos(int idCliente, string busca = "")
        {
            var contatos = repository.ObterTodosPeloIdCliente(idCliente);
            var retorno = new
            {
                data = contatos
            };
            return Json(retorno);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var contato = repository.ObterPeloId(id);

            if (contato == null)
                return NotFound();

            return Json(contato);
        }
    }
}