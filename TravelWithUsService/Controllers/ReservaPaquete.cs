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
        // GET: api/reservaPaquete/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReservaPaquete>))]
        public async Task<IEnumerable<ReservaPaquete>> GetReservasPaquetes(string genre)
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

        // GET: api/reservaPaquete/idA/codigoP/idT
        [HttpGet("{idA}/{codigoP}/{idT}")]
        [ProducesResponseType(200, Type = typeof(ReservaPaquete))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idA, int codigoP, int idT)
        {
           ReservaPaquete r = await this.repo.RetrieveAsync( idA, codigoP,  idT);

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
        public async Task<IActionResult> Create([FromBody]ReservaPaquete r)
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
                routeValues: new { idA = added.IdA, codigoP=added.codigo, idT=added.idT},  
                value: added
            );
        }

        // PUT: api/reservaPaquete/idA/codigoP/idT
        // BODY: ReservaPaquete (JSON)
        [HttpGet("{idA}/{codigoP}/{idT}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] ReservaPaquete r, int idA, int codigoP, int idT)
        {
            if (r== null || r.AgenciaID!= idA  || r.codigo != codigoP || r.TuristaID != idT)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync( idA, codigoP,  idT);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync( idA,  codigoP, idT, r);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/reservaPaquete/idA/codigoP/idT
        [HttpGet("{idA}/{codigoP}/{idT}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idA, int codigoP, int idT)
        {
            ReservaPaquete r = await this.repo.RetrieveAsync( idA, codigoP, idT);
            if (r == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idA,  codigoP,  idT);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"ReservaPaquete with id { idA,  codigoP, idT} was found but failed to delete."
                );
            }

        }
    }
    }
}











