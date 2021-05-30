using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/excursion
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionController : ControllerBase
    {
        private IExcursion repo;

        public ExcursionController(IExcursion repo)
        {
            this.repo = repo;
        }

        // GET: api/excursion
        // GET: api/excursion/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Excursion>))]
        public async Task<IEnumerable<Excursion>> GetExcursions(string genre)
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

        // GET: api/excursion/[id]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Excursion))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            Excursion excursion = await this.repo.RetrieveAsync(id);

            if (excursion == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(excursion);
            }
        }


        // POST: api/excursion
        // BODY: Excursion (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Excursion))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Excursion excursion)
        {
            if (excursion == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Excursion added = await repo.CreateAsync(excursion);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.ExcursionID },
                value: added
            );
        }

        // PUT: api/excursion/[id]
        // BODY: Excursion (JSON)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Excursion excursion, int id)
        {
            if (excursion == null || excursion.ExcursionID != id)
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

            await this.repo.UpdateAsync(id, excursion);

            return new NoContentResult();   // 204 No Content
        }
        // DELETE: api/excursion/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Excursion excursion = await this.repo.RetrieveAsync(id);
            if (excursion == null)
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
                    $"Excursion with id {id} was found but failed to delete."
                );
            }

        }
    }
}











