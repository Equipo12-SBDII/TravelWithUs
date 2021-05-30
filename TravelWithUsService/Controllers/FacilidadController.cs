using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/facilidad
    [Route("api/[controller]")]
    [ApiController]
    public class FacilidadController : ControllerBase
    {
        private IFacilidad repo;

        public FacilidadController(IFacilidad repo)
        {
            this.repo = repo;
        }

        // GET: api/facilidad
        // GET: api/facilidad/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Facilidad>))]
        public async Task<IEnumerable<Facilidad>> GetFacilidades(string genre)
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

        // GET: api/facilidad/[id]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Facilidad))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            Facilidad facilidad = await this.repo.RetrieveAsync(id);

            if (facilidad == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(facilidad);
            }
        }


        // POST: api/facilidad
        // BODY: Facilidad (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Facilidad))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Facilidad facilidad)
        {
            if (facilidad == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Facilidad added = await repo.CreateAsync(facilidad);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.FacilidadID },
                value: added
            );
        }

        // PUT: api/facilidad/[id]
        // BODY: Facilidad (JSON)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Facilidad facilidad, int id)
        {
            if (facilidad == null || facilidad.FacilidadID != id)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync(id);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync(id, facilidad);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/facilidad/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Facilidad facilidad = await this.repo.RetrieveAsync(id);
            if (facilidad == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(id);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"Facilidad with id {id} was found but failed to delete."
                );
            }

        }
    }
}











