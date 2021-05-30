using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/reservaIndividual
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaIndividualController : ControllerBase
    {
        private IReservaIndividual repo;

        public ReservaIndividualController(IReservaIndividual repo)
        {
            this.repo = repo;
        }

        // GET: api/reservaIndividual
        // GET: api/reservaIndividual/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReservaIndividual>))]
        public async Task<IEnumerable<ReservaIndividual>> GetReservasIndividuales(string genre)
        {
            if (string.IsNullOrEmpty(genre))
            {
                return await this.repo.RetrieveAllAsync();
            }
            else
            {
                return (await this.repo.RetrieveAllAsync())
                        .Where(f => f.Genre == genre);
            }
        }

        // GET: api/reservaIndividual/idA/idO/idT
        [HttpGet("{idA}/{idO}/{idT}")]
        [ProducesResponseType(200, Type = typeof(ReservaIndividual))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idA, int idO, int idT)
        {
           ReservaIndividual r = await this.repo.RetrieveAsync( idA, idO,  idT);

            if (r == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(r);
            }
        }


        // POST: api/reservaIndividual
        // BODY: ReservaIndividual (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReservaIndividual))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]ReservaIndividual r)
        {
            if (r == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            ReservaExcursion added = await repo.CreateAsync(r);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { idA = added.IdA, idO=added.IdO, idT=added.idT},  
                value: added
            );
        }

        // PUT: api/reservaIndividual/idA/idO/idT
        // BODY: ReservaIndividual (JSON)
        [HttpGet("{idA}/{idO}/{idT}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] ReservaIndividual r, int idA, int idO, int idT)
        {
            if (r== null || r.AgenciaID!= idA  || r.OfertaID != idO || r.TuristaID != idT)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync( idA, idO,  idT);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync( idA,  idO, idT, r);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/reservaIndividual/idA/idO/idT
        [HttpGet("{idA}/{idO}/{idT}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idA, int idO, int idT)
        {
            ReservaIndividual r = await this.repo.RetrieveAsync( idA,  idO, idT);
            if (r == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idA,  idO,  idT);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"ReservaIndividual with id { idA,  idE, idT} was found but failed to delete."
                );
            }

        }
    }
    }
}











