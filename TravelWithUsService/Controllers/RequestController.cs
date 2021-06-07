using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
// using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private DBContext.Repositories.IRequestsRepository repo;

        public RequestController(DBContext.Repositories.IRequestsRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/request/excursionExtendida
        [HttpGet("excursionExtendida")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.ExcursionExtendida>))]
        public async Task<IEnumerable<DBContext.Repositories.ExcursionExtendida>> GetExtendedExcursions()
        {
            return await this.repo.GetExtendedExcursion();
        }

        // GET: api/request/gananciaAgencia
        [HttpGet("gananciaAgencia")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.GananciaAgencia>))]
        public async Task<IEnumerable<DBContext.Repositories.GananciaAgencia>> GetAgenciesProfits(string genre)
        {
            return await this.repo.GetExpectedProfitAsync();
        }


        // GET: api/request/hotelInPackage
        [HttpGet("hotelInPackage")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
        public async Task<IEnumerable<DBContext.Repositories.HotelEnPaquete>> GetHotelInPackage(string genre)
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.TuristaIndividualRepitente>))]
        public async Task<IEnumerable<DBContext.Repositories.TuristaIndividualRepitente>> GetRepetitiveTourist(string genre)
        {
            return await this.repo.GetRepetitiveTouristAsync();
        }


        // GET: api/request/packagesOverMean
        [HttpGet("packagesOverMean")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Paquete>))]
        public async Task<IEnumerable<DBContext.Repositories.PaqueteSobreMedia>> GetPackagesOverMean()
        {
            return await this.repo.GetPackagesOverMean();
        }

        // GET: api/request/individualReservation
        [HttpGet("individualReservation")]
        [ProducesResponseType(200, Type = typeof(DBContext.Repositories.ReservaIndividualOpciones))]
        public async Task<DBContext.Repositories.ReservaIndividualOpciones> GetIndividualReservationOptions()
        {
            return await this.repo.GetRIOptions();
        }

        // GET: api/request/agenciaReserva
        [HttpGet("agenciaReserva")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.AgenciaParaReserva>))]
        public async Task<IEnumerable<DBContext.Repositories.AgenciaParaReserva>> GetAgenciaParaReservasAsync()
        {
            return await this.repo.GetAgenciesReserve();
        }

        // GET: api/request/ofertaReserva
        [HttpGet("ofertaReserva")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.OfertaParaReserva>))]
        public async Task<IEnumerable<DBContext.Repositories.OfertaParaReserva>> GetOfertaParaReservasAsync()
        {
            return await this.repo.GetOfferReserve();
        }
        // GET: api/request/turistaReserva
        [HttpGet("turistaReserva")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.OfertaParaReserva>))]
        public async Task<IEnumerable<DBContext.Repositories.TuristaParaReserva>> GetTuristaParaReservasAsync()
        {
            return await this.repo.GetTouristReserve();
        }

        [HttpGet("reservasInd")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DBContext.Repositories.OfertaParaReserva>))]
        public async Task<IEnumerable<DBContext.Repositories.ReservaIndividualShow>> GetReservaIndividualShows()
        {
            return await this.repo.GetReservaIndividualShows();
        }
    }
}
