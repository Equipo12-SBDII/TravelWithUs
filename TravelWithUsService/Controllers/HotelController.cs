using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
// using TravelWithUsService.DBContext.Repositories;
using TravelWithUsService.Models;

namespace TravelWithUsService.Controllers
{  // base address: api/hotel
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private DBContext.Repositories.IHotel repo;

        public HotelController(DBContext.Repositories.IHotel repo)
        {
            this.repo = repo;
        }


        // GET: api/hotel
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hotel>))]
        public async Task<IEnumerable<Hotel>> GetHoteles()
        {
            return await this.repo.RetrieveAllAsync();
        }


        // GET: api/hotel/[id]
        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Hotel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            Hotel hotel = await this.repo.RetrieveAsync(id);

            if (hotel == null)
            {
                return NotFound(); // 404 resource not found
            }
            else
            {
                return Ok(hotel);
            }
        }


        // POST: api/hotel
        // BODY: Hotel (JSON)
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Hotel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest();  // 400 Bad Request
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad Request
            }

            Hotel added = await repo.CreateAsync(hotel);

            return CreatedAtRoute( // 201 Created
                routeName: nameof(this.Get),
                routeValues: new { id = added.HotelID },
                value: added
            );
        }

        // PUT: api/hotel/[id]
        // BODY: Hotel (JSON)
        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromBody] Hotel hotel, int id)
        {
            if (hotel == null || hotel.HotelID != id)
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

            await this.repo.UpdateAsync(id, hotel);

            return new NoContentResult();   // 204 No Content

        }

        // DELETE: api/hotel/[id]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            Hotel hotel = await this.repo.RetrieveAsync(id);
            if (hotel == null)
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
                    $"Hotel with id {id} was found but failed to delete."
                );
            }

        }
    }
}










