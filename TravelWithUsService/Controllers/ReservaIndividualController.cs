using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
// using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/reservaIndividual
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaIndividualController : ControllerBase
    {
        private DBContext.Repositories.IReservaIndividual repo;

        public ReservaIndividualController(DBContext.Repositories.IReservaIndividual repo)
        {
            this.repo = repo;
        }

        // GET: api/reservaIndividual
        // GET: api/reservaIndividual/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReservaIndividual>))]
        public async Task<IEnumerable<ReservaIndividual>> GetReservasIndividuales(string genre)
        {
            return await this.repo.RetrieveAllAsync();
        }

        // GET: api/reservaIndividual/idA/idO/idT
        [HttpGet("{idA:int}/{idH:int}/{idO:int}/{idT:int}")]
        [ProducesResponseType(200, Type = typeof(ReservaIndividual))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idRi, int idA, int idH, int idO, int idT)
        {
            ReservaIndividual r = await this.repo.RetrieveAsync(idRi, idA, idH, idO, idT);

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
        public async Task<IActionResult> Create([FromBody] ReservaIndividual ri)
        {
            if (ri == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            ReservaIndividual added = await repo.CreateAsync(ri);

            // return CreatedAtRoute( // 201 Created
            //     routeName: nameof(this.Get),
            //     routeValues: new { idA = added.AgenciaID, idH = added.HotelID, idO = added.OfertaID, idT = added.TuristaID },
            //     value: added
            // );
            return StatusCode(201);
        }

        // PUT: api/reservaIndividual/idA/idO/idT
        // BODY: ReservaIndividual (JSON)
        [HttpPut("{idA:int}/{idH:int}/{idO:int}/{idT:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] ReservaIndividual ri, int idRi, int idH, int idA, int idO, int idT)
        {
            if (ri == null || ri.AgenciaID != idA || ri.HotelID != idO || ri.OfertaID != idO || ri.TuristaID != idT)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync(idRi, idA, idH, idO, idT);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync(existing, idRi, idA, idH, idO, idT);

            return new NoContentResult();   // 204 No Content
        }


        // DELETE: api/reservaIndividual/idA/idO/idT
        [HttpDelete("{idA:int}/{idH:int}/{idO:int}/{idT:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idRi, int idA, int idH, int idO, int idT)
        {
            ReservaIndividual r = await this.repo.RetrieveAsync(idRi, idA, idH, idO, idT);
            if (r == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idRi, idA, idH, idO, idT);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"ReservaIndividual with id ({idA}, {idH}, {idO}, {idT}) was found but failed to delete."
                );
            }

        }
    }
}
