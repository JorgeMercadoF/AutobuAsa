using AutobuAsa.Models;
using AutobuAsa.Models.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutobuAsa.Controllers
{
    public class CiudadesController : Controller
    {
        private IRepositorio Repository = new Repository();

        // GET: Ciudades
        public async Task<ActionResult> Index()
        {
            return View(await Repository.GetAllCities().ToListAsync());
        }

        // GET: Ciudades/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Ciudad ciudad = await Repository.GetCityAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,codigo")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                Repository.AddCity(ciudad);
                return RedirectToAction("Index");
            }

            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Ciudad ciudad = await Repository.GetCityAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,codigo")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateCityAsync(ciudad);
                return RedirectToAction("Index");
            }
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Ciudad ciudad = await Repository.GetCityAsync(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ciudad ciudad = await Repository.GetCityAsync(id);
            Repository.DeleteCity(ciudad);
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
    }
}
