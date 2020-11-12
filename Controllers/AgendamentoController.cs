using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoViverBem.Context;
using AgendamentoViverBem.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoViverBem.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly ApplicationContext _context;

        public AgendamentoController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult ListarAgendamentos()
        {
            try
            {
                var agendamentos = _context.Agendamento.ToList();
                return View(agendamentos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Agendamento agendamento)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Dados inválidos");

                _context.Agendamento.Add(agendamento);
                _context.SaveChanges();

                return RedirectToAction("ListarAgendamentos", "Agendamento");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
