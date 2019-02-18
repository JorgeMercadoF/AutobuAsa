using System.Linq;
using System.Threading.Tasks;

namespace AutobuAsa.Models.Repositories
{
    public interface IRepositorio
    {
        bool AddCity(Ciudad City);
        void AddCityAsync(Ciudad City);
        bool UpdateCity(Ciudad City);
        void UpdateCityAsync(Ciudad City);
        bool DeleteCity(Ciudad City);
        void DeleteCityAsync(Ciudad City);
        Ciudad GetCity(int CityId);
        Task<Ciudad> GetCityAsync(int CiudadId);
        IQueryable<Ciudad> GetAllCities();


        bool AddRoute(Ruta Route);
        void AddRouteAsync(Ruta Route);
        bool UpdateRoute(Ruta Route);
        void UpdateRouteAsync(Ruta Route);
        bool DeleteRoute(Ruta Route);
        void DeleteRouteAsync(Ruta Route);
        Ruta GetRoute(int RouteId);
        Task<Ruta> GetRouteAsync(int RutaId);
        IQueryable<Ruta> GetAllRoutes();


        void Dispose();
    }
}