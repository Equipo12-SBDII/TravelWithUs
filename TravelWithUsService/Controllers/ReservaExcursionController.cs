using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/reservaExcursion
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaExcursionController : ControllerBase
    {
        private IReservaExcursion repo;

        public ReservaExcursionController(IReservaExcursion repo)
        {
            this.repo = repo;
        }

        // GET: api/reservaExcursion
        // GET: api/reservaExcursion/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReservaExcursion>))]
        public async Task<IEnumerable<ReservaExcursion>> GetReservasExcursiones(string genre)
        {
            return await this.repo.RetrieveAllAsync();
        }

        // GET: api/reservaExcursion/[idA]/[idE]/[idT]
        [HttpGet("{idA:int}/{idE:int}/{idT:int}")]
        [ProducesResponseType(200, Type = typeof(ReservaExcursion))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idA, int idE, int idT)
        {
            ReservaExcursion r = await this.repo.RetrieveAsync(idA, idE, idT);

            if (r == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(r);
            }
        }


        // POST: api/reservaExcursion
        // BODY: ReservaExcursion (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReservaExcursion))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ReservaExcursion r)
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
                routeValues: new { idA = added.AgenciaID, idE = added.ExcursionID, idT = added.TuristaID },
                value: added
            );
        }

        // PUT: api/reservaExcursion/idA/idE/idT
        // BODY: ReservaExcursion (JSON)
        [HttpGet("{idA:int}/{idE:int}/{idT:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] ReservaExcursion re, int idA, int idE, int idT)
        {
            if (re == null || re.AgenciaID != idA || re.ExcursionID != idE || re.TuristaID != idT)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync(idA, idE, idT);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync(re, idA, idE, idT);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/reservaExcursion/idA/idE/idT
        [HttpGet("{idA:int}/{idE:int}/{idT:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idA, int idE, int idT)
        {
            ReservaExcursion r = await this.repo.RetrieveAsync(idA, idE, idT);
            if (r == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idA, idE, idT);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"ReservaExcursion with id ({idA}, {idE}, {idT}) was found but failed to delete."
                );
            }

        }
    }
}
