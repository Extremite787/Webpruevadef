using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Partida.Modelos;
using Partida.ModelosNuevos;

namespace Webpruevadef.Controllers
{
    public class TipoVehiculosController : Controller
    {
        private readonly EjercicioEvaluacionContext _context;
        public TipoVehiculosController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }
        // GET: TipoVehiculosController
        public ActionResult Index()
        {
            List<TipoVehiculo> lsttipovehiculo = _context.TipoVehiculos.ToList();
            return View(lsttipovehiculo);
        }

        // GET: TipoVehiculosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoVehiculosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoVehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoVehiculosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoVehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoVehiculosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoVehiculosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
