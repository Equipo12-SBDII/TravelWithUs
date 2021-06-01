using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private IRequestsRepository repo;

        public RequestController(IRequestsRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/request/excursionExtendida
        [HttpGet("excursionExtendida")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ExcursionExtendida>))]
        public async Task<IEnumerable<ExcursionExtendida>> GetExtendedExcursions()
        {
            return await this.repo.GetExtendedExcursion();
        }

        // GET: api/request/gananciaAgencia
        [HttpGet("gananciaAgencia")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GananciaAgencia>))]
        public async Task<IEnumerable<GananciaAgencia>> GetAgenciesProfits(string genre)
        {
            return await this.repo.GetExpectedProfitAsync();
        }


        // GET: api/request/hotelInPackage
        [HttpGet("hotelInPackage")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
        public async Task<IEnumerable<Hotel>> GetHotelInPackage(string genre)
        {
            return await this.repo.GetHotelsInPackagesAsync();
        }

        // GET: api/request/hotelInPackage/1
        [HttpGet("hotelinPackage/{idP:int}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
        public async Task<IEnumerable<Hotel>> GetHotelInPackage(int idP)
        {
            return await this.repo.GetHotelsInPackagesAsync(idP);
        }


        // GET: api/request/repetitiveTourist
        [HttpGet("repetitiveTourist")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TuristaIndividualRepitente>))]
        public async Task<IEnumerable<TuristaIndividualRepitente>> GetRepetitiveTourist(string genre)
        {
            return await this.repo.GetRepetitiveTouristAsync();
        }


        // GET: api/request/packagesOverMean
        [HttpGet("packagesOverMean")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Paquete>))]
        public async Task<PaqueteSobreMedia> GetPackagesOverMean()
        {
            return await this.repo.GetPackagesOverMean();
        }


    }
}
