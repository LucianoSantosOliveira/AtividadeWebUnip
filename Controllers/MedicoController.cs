using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoViverBem.Context;
using AgendamentoViverBem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AgendamentoViverBem.Controllers
{

    public class MedicoController : Controller
    {
        private readonly ApplicationContext _context;

        public  MedicoController(ApplicationContext context)
        {
            _context = context;
        }

        public ActionResult ListarMedico()
        {
            try
            {
                var medico = _context.Medico.ToList();
                return View(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Atualizar(int id)
        {
            try
            {
                var medico = _context.Medico.Where(m => m.IdMedico == id).FirstOrDefault();
                return View(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult BuscarId(int id)
        {
            try
            {
                var medico = _context.Medico.Where(m => m.IdMedico == id).FirstOrDefault();
                return View(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Atualizar(Medico medico)
        {
            try
            {
                _context.Entry(medico).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("ListarMedico", "Medico");
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
        public ActionResult Cadastrar(Medico medico)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Dados inválidos");

                _context.Medico.Add(medico);
                _context.SaveChanges();

                return RedirectToAction("ListarMedico", "Medico");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Deletar(int Id)
        {
            try
            {
                var medico =  _context.Medico.Where(m => m.IdMedico == Id).FirstOrDefault();
                return View(medico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Deletar(Medico medico)
        {
            try
            {
                _context.Medico.Remove(medico);
                _context.SaveChanges();
                return RedirectToAction("ListarMedico", "Medico");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
} 
