using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalKingDomWebApi.Models;
using Microsoft.AspNetCore.Cors;

namespace AnimalKingDomWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalDetailsController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public AnimalDetailsController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/AnimalDetails
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<IEnumerable<AnimalDetails>>> GetAnimalDetails()
        {
            return await _context.AnimalDetails.ToListAsync();
        }

        // GET: api/AnimalDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDetails>> GetAnimalDetails(int id)
        {
            var animalDetails = await _context.AnimalDetails.FindAsync(id);

            if (animalDetails == null)
            {
                return NotFound();
            }

            return animalDetails;
        }
        [HttpGet("{keyword}")]
        [Route("search/{keyword}")]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<AnimalDetails>> GetAnimalDetails(string keyword)
        {
            var animalDetails = await _context.AnimalDetails.Where(x => x.Name == keyword.ToUpper()).FirstOrDefaultAsync();

            if (animalDetails == null)
            {
                return NotFound();
            }

            return animalDetails;
        }

        // PUT: api/AnimalDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalDetails(int id, AnimalDetails animalDetails)
        {
            if (id != animalDetails.AnimalId)
            {
                return BadRequest();
            }

            _context.Entry(animalDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnimalDetails
        [HttpPost]
        public async Task<ActionResult<AnimalDetails>> PostAnimalDetails(AnimalDetails animalDetails)
        {
            _context.AnimalDetails.Add(animalDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalDetails", new { id = animalDetails.AnimalId }, animalDetails);
        }

        // DELETE: api/AnimalDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalDetails>> DeleteAnimalDetails(int id)
        {
            var animalDetails = await _context.AnimalDetails.FindAsync(id);
            if (animalDetails == null)
            {
                return NotFound();
            }

            _context.AnimalDetails.Remove(animalDetails);
            await _context.SaveChangesAsync();

            return animalDetails;
        }

        private bool AnimalDetailsExists(int id)
        {
            return _context.AnimalDetails.Any(e => e.AnimalId == id);
        }
    }
}
