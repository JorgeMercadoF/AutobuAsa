using AutobuAsa.Models;
using AutobuAsa.Models.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutobuAsa.Controllers
{
    public class RutasController : Controller
    {
        //private AutobusAsaEntities db = new AutobusAsaEntities();
        private IRepositorio Repository = new Repository();

        #region Views
        // GET: Rutas
        public async Task<ActionResult> Index()
        {
            var ruta = Repository.GetAllRoutes().Include(r => r.Ciudad).Include(r => r.Ciudad1);
            return View(await ruta.ToListAsync());
        }

        // GET: Rutas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Ruta ruta = await Repository.GetRouteAsync(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre");
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre");
            return View();
        }

        // GET: Rutas/Buscar
        public ActionResult Buscar()
        {
            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre");
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre");
            return View();
        }
        #endregion

        #region Datos
        // POST: Rutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ciudadOrigen,ciudadDestino,km,precio")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                Repository.AddRoute(ruta);
                Repository.UpdateRoute(ruta);
                return RedirectToAction("Index");
            }

            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre", ruta.ciudadOrigen);
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre", ruta.ciudadDestino);
            return View(ruta);
        }

        // GET: Rutas/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Ruta ruta = await Repository.GetRouteAsync(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }

            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre", ruta.ciudadOrigen);
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre", ruta.ciudadDestino);
            return View(ruta);
        }

        // POST: Rutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ciudadOrigen,ciudadDestino,km,precio")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateRoute(ruta);
                return RedirectToAction("Index");
            }

            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre", ruta.ciudadOrigen);
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre", ruta.ciudadDestino);
            return View(ruta);
        }

        // GET: Rutas/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Ruta ruta = await Repository.GetRouteAsync(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ruta ruta = await Repository.GetRouteAsync(id);
            Repository.DeleteRoute(ruta);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET Rutas/Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Buscar([Bind(Include = "ciudadOrigen,ciudadDestino")] Ruta Ruta)
        {
            var items = Repository.GetAllCities();
            ViewBag.ciudadOrigen = new SelectList(items, "id", "nombre");
            ViewBag.ciudadDestino = new SelectList(items, "id", "nombre");
            return View(Ruta);
        }

        public void BuscarRutas(Ruta RutaOriginal)
        {
            
        }
        #endregion
    }
}
