using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/paquete
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        private IPaquete repo;

        public PaqueteController(IPaquete repo)
        {
            this.repo = repo;
        }

        // GET: api/paquete
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Paquete>))]
        public async Task<IEnumerable<Paquete>> GetPaquetes()
        {
            return await this.repo.RetrieveAllAsync();
        }

        // GET: api/paquete/[id]
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Paquete))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            Paquete paquete = await this.repo.RetrieveAsync(id);

            if (paquete == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(paquete);
            }
        }


        // POST: api/paquete
        // BODY:Paquete (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Paquete))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Paquete paquete)
        {
            if (paquete == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Paquete added = await this.repo.CreateAsync(paquete);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.Codigo },
                value: added
            );
        }

        // PUT: api/paquete/[id]
        // BODY: Paquete (JSON)
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Paquete paquete, int id)
        {
            if (paquete == null || paquete.Codigo != id)
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

            await this.repo.UpdateAsync(id, paquete);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/paquete/[id]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Paquete paquete = await this.repo.RetrieveAsync(id);
            if (paquete == null)
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
                    $"Paquete with id {id} was found but failed to delete."
                );
            }

        }
    }
}
