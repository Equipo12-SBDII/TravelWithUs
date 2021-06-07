using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/oferta
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private IOferta repo;

        public OfertaController(IOferta repo)
        {
            this.repo = repo;
        }

        // GET: api/oferta
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Oferta>))]
        public async Task<IEnumerable<Oferta>> GetOfertas(string genre)
        {
            return await this.repo.RetrieveAllAsync();
        }

        // GET: api/oferta/[idO]/[IdH]
        [HttpGet("{idO:int}/{idH:int}")]
        [ProducesResponseType(200, Type = typeof(Hotel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int idO, int idH)
        {
            Oferta oferta = await this.repo.RetrieveAsync(idO, idH);

            if (oferta == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(oferta);
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
                routeValues: new { idO = added.OfertaID, idH = added.HotelID },
                value: added
            );
        }

        // PUT: api/oferta/[idO]/[idH]
        // BODY: Oferta (JSON)
        [HttpPut("{idO:int}/{idH:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Oferta oferta, int idO, int idH)
        {
            if (oferta == null || oferta.OfertaID != idO || oferta.HotelID != idH)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request
            }

            var existing = await this.repo.RetrieveAsync(idO, idH);

            if (existing == null)
            {
                return NotFound();  // 404 Resource not found
            }

            await this.repo.UpdateAsync(oferta, idO, idH);

            return new NoContentResult();   // 204 No Content
        }

        // DELETE: api/oferta/[idO]/[idH]
        [HttpDelete("{idO:int}/{idH:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int idO, int idH)
        {
            Oferta oferta = await this.repo.RetrieveAsync(idO, idH);
            if (oferta == null)
            {
                return NotFound();  // 404 Resource No Found
            }

            bool? deleted = await this.repo.DeleteAsync(idO, idH);
            if (deleted.HasValue && deleted.Value)
            {
                return new NoContentResult();   // 204 No Content
            }
            else
            {
                return BadRequest(  // 400 Bad Request
                    $"Oferta with id ({idO}, {idH}) was found but failed to delete."
                );
            }

        }
    }
}












