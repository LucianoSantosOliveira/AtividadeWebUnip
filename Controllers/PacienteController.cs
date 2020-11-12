using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoViverBem.Context;
using AgendamentoViverBem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgendamentoViverBem.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationContext _context;

        public PacienteController(ApplicationContext context)
        {
            _context = context;
        }

        public ActionResult ListarPacientes()
        {
            try
            {
                var pacientes = _context.Paciente.ToList();
                return View(pacientes);
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
        public ActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Dados inválidos");

                _context.Paciente.Add(paciente);
                _context.SaveChanges();

                return RedirectToAction("ListarPacientes", "Paciente");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Atualizar(int Id)
        {
            try
            {
                var paciente = _context.Paciente.Where(P => P.IdPaciente == Id).FirstOrDefault();
                return View(paciente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        [HttpGet]
        public ActionResult BuscarId(int Id)
        {
            try
            {
                var paciente = _context.Paciente.Where(p => p.IdPaciente == Id).FirstOrDefault();
                return View(paciente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Atualizar(Paciente paciente)
        {
            try
            {
                _context.Entry(paciente).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("ListarPacientes", "Paciente");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public ActionResult Deletar(int Id)
        {
            try
            {
                var Paciente = _context.Paciente.Where(P => P.IdPaciente == Id).FirstOrDefault();
                return View(Paciente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult Deletar(Paciente paciente)
        {
            try
            {
                _context.Paciente.Remove(paciente);
                _context.SaveChanges();
                return RedirectToAction("ListarPacientes", "Paciente");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
