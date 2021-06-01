using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/agencia

  public class RequestRepositoryController:ControllerBase
  { 

    private IRequestsRepository rep ;
    
    public RequestRepositoryController(IRequestsRepository repo)
    {
        this.repo = repo;
    }
            
    // GET: api/excursionExtendida
    // GET: api/excursionextendida/?genre=[genre]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Excursionextendida>))]
    public async Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursions(string genre)
    {
        return await this.repo.GetExtendedExcursion();
    }
   
    // GET: api/ganancia
    // GET: api/ganancia/?genre=[genre]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<GananciaAgencia>))]
    public async Task<IEnumerable<GananciaAgencia>> GetAgenciesProfits(string genre)
    {
        return await this.repo.GetExpectedProfitAsync();
    }


    // GET: api/hotelInPackage
    // GET: api/hotelInPackage/?genre=[genre]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
    public async Task<IEnumerable<Hotel>> GetHotelInPackage(string genre)
    {
        return await this.repo.GetHotelsInPackagesAsync();
    }

    
    // GET: api/repetitiveTourist
    // GET: api/repetitiveTourist/?genre=[genre]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<GananciaAgencia>))]
    public async Task<IEnumerable<PaqueteSobreMedia>> GetRepetitiveTourist(string genre)
    {
        return await this.repo.GetRepetitiveTouristAsync();
    }
   
  }
        



  // GET: api/paquete
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Paquete>))]
        public async Task<IEnumerable<Paquete>> GetPaquetes()
        {
            return await this.repo.RetrieveAllAsync();
        }


}
