using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/agencia
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciaController : ControllerBase
    {
        private IAgencia repo;

        public AgenciaController(IAgencia repo)
        {
            this.repo = repo;
        }


        
        // GET: api/agencia
        // GET: api/agencia/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Agencia>))]
        public async Task<IEnumerable<Agencia>> GetAgencies(string genre)
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

        // GET: api/agencia/[id]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Agencia))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAgencia(int id)
        {
            Agencia agencia = await this.repo.RetrieveAsync(id);

            if (agencia == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(agencia);
            }
        }


        // POST: api/agencia
        // BODY: Agencia (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Agencia))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Agencia agencia)
        {
            if (agencia == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Agencia added = await repo.CreateAsync(agencia);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.GetAgencia),
                routeValues: new { id = added.AgenciaID },
                value: added
            );
        }

        // PUT: api/agencia/[id]
        // BODY: Agencia (JSON)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Agencia agencia, int id)
        {
            if (agencia == null || agencia.AgenciaID != id)
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

            await this.repo.UpdateAsync(id, agencia);

            return new NoContentResult();   // 204 No Content

        }
        // DELETE: api/agencia/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Agencia agencia = await this.repo.RetrieveAsync(id);
            if (agencia == null)
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
                    $"Agencia with id {id} was found but failed to delete."
                );
            }

        }
    }
}











