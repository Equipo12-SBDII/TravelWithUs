using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/reservaPaquete
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaPaqueteController : ControllerBase
    {
        private IReservaPaquete repo;

        public ReservaPaqueteController(IReservaPaquete repo)
        {
            this.repo = repo;
        }

        // GET: api/reservaPaquete
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReservaPaquete>))]
        public async Task<IEnumerable<ReservaPaquete>> GetReservasPaquetes(string genre)
        {
            return await this.repo.RetrieveAllAsync();
        }

        // GET: api/reservaPaquete/[idA]/[idT]/[codigoP]
        [HttpGet("{idA:int}/{idT:int}/{codigoP:int}")]
        [ProducesResponseType(200, Type = typeof(ReservaPaquete))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idA, int idT, int codigoP)
        {
            ReservaPaquete r = await this.repo.RetrieveAsync(idA, idT, codigoP);

            if (r == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(r);
            }
        }


        // POST: api/reservaPaquete
        // BODY: ReservaPaquete (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ReservaPaquete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] ReservaPaquete r)
        {
            if (r == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            ReservaPaquete added = await repo.CreateAsync(r);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { idA = added.AgenciaID, idT = added.TuristaID, codigoP = added.Codigo },
                value: added
            );
        }

        // PUT: api/reservaPaquete/[idA]/[idT]/[codigoP]
        // BODY: ReservaPaquete (JSON)
        [HttpPut("{idA:int}/{idT:int}/{codigoP:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] ReservaPaquete rp, int idA, int idT, int codigoP)
        {
            if (rp == null || rp.AgenciaID != idA || rp.TuristaID != idT || rp.Codigo != codigoP)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync(idA, idT, codigoP);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync(rp, idA, idT, codigoP);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/reservaPaquete/idA/codigoP/idT
        [HttpGet("{idA:int}/{idT:int}/{codigoP:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idA, int idT, int codigoP)
        {
            ReservaPaquete r = await this.repo.RetrieveAsync(idA, idT, codigoP);
            if (r == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idA, idT, codigoP);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"ReservaPaquete with id ({idA}, {idT}, {codigoP}) was found but failed to delete."
                );
            }

        }
    }
}
