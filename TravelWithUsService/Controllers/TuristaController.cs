using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/turista
    [Route("api/[controller]")]
    [ApiController]
    public class TuristaController : ControllerBase
    {
        private ITurista repo;

        public Turista Controller(ITurista repo)
        {
            this.repo = repo;
        }


        
        // GET: api/turista 
        // GET: api/turista /?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Turista >))]
        public async Task<IEnumerable<Turista >> GetTuristas(string genre)
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

        // GET: api/turista /[id]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Turista ))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get (int id)
        {
            Turista  turista  = await this.repo.RetrieveAsync(id);

            if (turista == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(turista );
            }
        }


        // POST: api/turista 
        // BODY: Turista  (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Turista ))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody]Turista turista )
        {
            if (turista  == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Agencia added = await repo.CreateAsync(turista );

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.TuristaID },
                value: added
            );
        }

        // PUT: api/turista /[id]
        // BODY: Turista  (JSON)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Turista  turista , int id)
        {
            if (turista  == null || turista.TuristaID!= id)
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

            await this.repo.UpdateAsync(id, turista );

            return new NoContentResult();   // 204 No Content

        }
        // DELETE: api/turista /[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Turista  turista = await this.repo.RetrieveAsync(id);
            if (turista == null)
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
                    $"Turista  with id {id} was found but failed to delete."
                );
            }

        }
    }
}











