using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Partida.Modelos;
using Partida.ModelosNuevos;
using Partida.ViewModel;

namespace Webpruevadef.Controllers
{
    public class TipoVehiculosController : Controller
    {
        private readonly EjercicioEvaluacionContext _context;
        public TipoVehiculosController(EjercicioEvaluacionContext context)
        {
            _context = context;
        }
        public void Combox()
        {
            ViewData["CodigoVehiculo"] = new SelectList(_context.Vehiculos.Select(x => new Vehiculoscuenta()
            { 
                Codigo = x.Codigo,
                Nombre = $"{x.Nombre}",
                Estado = x.Estado
            }).Where(s=>s.Estado ==1).ToList(),"Codigo","Nombre");
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
            TipoVehiculo tipoVehiculo = _context.TipoVehiculos.Where(x => x.Codigo == id).FirstOrDefault();
            return View(tipoVehiculo);
        }

        // GET: TipoVehiculosController/Create
        public ActionResult Create()
        {
            Combox();
            return View();
        }

        // POST: TipoVehiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoVehiculo tipoVehiculo)
        {
            try
            {
                tipoVehiculo.Estado = 1;
                _context.Add(tipoVehiculo);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                Combox();
                return View(tipoVehiculo);
            }
        }

        // GET: TipoVehiculosController/Edit/5
        public ActionResult Edit(int id)
        {
            Combox();
            TipoVehiculo tipoVehiculo = _context.TipoVehiculos.Where(x => x.Codigo == id).FirstOrDefault();
            return View(tipoVehiculo);
        }

        // POST: TipoVehiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(tipoVehiculo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Combox();
                return View(tipoVehiculo);
            }
        }

        // GET: TipoVehiculosController/Delete/5
        public ActionResult Desactivar(int id)
        {
            TipoVehiculo tipoVehiculo = _context.TipoVehiculos.Where(x => x.Codigo == id).FirstOrDefault();
            tipoVehiculo.Estado = 0;
            _context.Update(tipoVehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Activar(int id)
        {
            TipoVehiculo tipoVehiculo = _context.TipoVehiculos.Where(x => x.Codigo == id).FirstOrDefault();
            tipoVehiculo.Estado = 1;
            _context.Update(tipoVehiculo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
