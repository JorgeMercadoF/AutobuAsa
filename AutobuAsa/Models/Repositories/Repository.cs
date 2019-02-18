using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AutobuAsa.Models.Repositories
{
    public class Repository : AutobusAsaEntities, IRepositorio
    {
        #region Rutas
        public bool AddRoute(Ruta Route)
        {
            this.Ruta.Add(Route);
            SaveChanges();
            return true;
        }

        public void AddRouteAsync(Ruta Route)
        {
            this.Ruta.Add(Route);
            SaveChanges();
        }

        public bool UpdateRoute(Ruta Route)
        {
            Entry(Route).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public void UpdateRouteAsync(Ruta Route)
        {
            Entry(Route).State = EntityState.Modified;
            SaveChangesAsync();
        }

        public bool DeleteRoute(Ruta Route)
        {
            this.Ruta.Remove(Route);
            SaveChanges();
            return true;
        }

        public void DeleteRouteAsync(Ruta Route)
        {
            this.Ruta.Remove(Route);
            SaveChanges();
        }

        public Ruta GetRoute(int RouteId)
        {
            Ruta Result = this.GetAllRoutes().Where(c => c.id == RouteId).SingleOrDefault();
            return Result;
        }

        public Task<Ruta> GetRouteAsync(int RouteId)
        {
            return this.Ruta.FindAsync(RouteId);
        }

        public IQueryable<Ruta> GetAllRoutes()
        {
            return this.Ruta.AsQueryable();
        }
        #endregion

        #region Ciudades
        public bool AddCity(Ciudad City)
        {
            this.Ciudad.Add(City);
            SaveChanges();
            return true;
        }

        public void AddCityAsync(Ciudad City)
        {
            this.Ciudad.Add(City);
            SaveChanges();
        }

        public bool DeleteCity(Ciudad City)
        {
            this.Ciudad.Remove(City);
            SaveChanges();
            return true;
        }

        public void DeleteCityAsync(Ciudad City)
        {
            this.Ciudad.Remove(City);
            SaveChanges();
        }

        public bool UpdateCity(Ciudad City)
        {
            Entry(City).State = EntityState.Modified;
            SaveChanges();
            return true;
        }

        public void UpdateCityAsync(Ciudad Ciudad)
        {
            Entry(Ciudad).State = EntityState.Modified;
            SaveChangesAsync();
        }

        public Ciudad GetCity(int CityId)
        {
            Ciudad Result = this.GetAllCities().Where(c => c.id == CityId).SingleOrDefault();
            return Result;
        }

        public Task<Ciudad> GetCityAsync(int CiudadId)
        {
            return this.Ciudad.FindAsync(CiudadId);
        }

        public IQueryable<Ciudad> GetAllCities()
        {
            return this.Ciudad.AsQueryable();
        }
        #endregion
    }
}