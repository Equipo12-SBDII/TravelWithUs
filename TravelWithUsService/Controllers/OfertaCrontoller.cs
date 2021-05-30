using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUs.DBContext.Repositories;
using TravelWithUs.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/oferta
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private IOferta repo;

        public OfertaController(IHotel repo)
        {
            this.repo = repo;
        }

        // GET: api/oferta
        // GET: api/oferta/?genre=[genre]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Oferta>))]
        public async Task<IEnumerable<Oferta>> GetOfertas(string genre)
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

        // GET: api/oferta/[id]
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Hotel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            Oferta oferta = await this.repo.RetrieveAsync(id);

            if (oferta == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(oferta );
            }
        }


        // POST: api/oferta
        // BODY: Oferta (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Oferta))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Oferta oferta)
        {
            if (oferta == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Oferta added = await repo.CreateAsync(oferta);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.OfertaID},
                value: added
            );
        }

        // PUT: api/oferta/[id]
        // BODY: Oferta (JSON)
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Oferta oferta, int id)
        {
            if (oferta == null || oferta.OfertaID!= id)
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

            await this.repo.UpdateAsync(id, oferta);

            return new NoContentResult();   // 204 No Content
        }


        // DELETE: api/oferta/[id]
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Oferta oferta = await this.repo.RetrieveAsync(id);
            if (oferta == null)
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
                    $"Oferta with id {id} was found but failed to delete."
                );
            }

        }
    }
    }
}











