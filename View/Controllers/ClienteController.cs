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
    [Route("cliente")]
    public class ClienteController : Controller
    {
        private IClienteRepository repository;

        public ClienteController(IClienteRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("cadastro")]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpGet, Route("editar")]
        public ActionResult Editar(int id)
        {
            var cliente = repository.ObterPeloId(id);
            if (cliente == null)
                return NotFound();

            ViewBag.Cliente = cliente;
            return View();
        }

        [HttpPost, Route("editar")]
        public ActionResult Editar(Cliente cliente)
        {
            var alterou = repository.Alterar(cliente);
            var resultado = new { status = alterou };
            return Json(resultado);
        }

        [HttpPost, Route("cadastro")]
        public ActionResult Cadastro(Cliente cliente)
        {
            var id = repository.Inserir(cliente);
            return RedirectToAction("Editar", new { id = id });
        }

        [HttpGet, Route("apagar")]
        public ActionResult Apagar(int id)
        {
            var apagou = repository.Apagar(id);
            var resultado = new { status = apagou };
            return Json(resultado);
        }

        [HttpGet, Route("obterpeloid")]
        public ActionResult ObterPeloId(int id)
        {
            var cliente = repository.ObterPeloId(id);

            if (cliente == null)
                return NotFound();

            return Json(cliente);
        }

        [HttpGet, Route("obtertodos")]
        public JsonResult ObterTodos(string busca = "")
        {
            var clientes = repository.ObterTodos(busca);
            var retorno = new
            {
                data = clientes
            };
            return Json(retorno);
        }
    }
}