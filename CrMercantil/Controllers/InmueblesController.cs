using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrMercantil.Models;

namespace CrMercantil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public InmueblesController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/Inmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetInmuebles()
        {
          if (_context.Inmuebles == null)
          {
              return NotFound();
          }
            return await _context.Inmuebles.ToListAsync();
        }

        // GET: api/Inmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> GetInmueble(string id)
        {
          if (_context.Inmuebles == null)
          {
              return NotFound();
          }
            var inmueble = await _context.Inmuebles.FindAsync(id);

            if (inmueble == null)
            {
                return NotFound();
            }

            return inmueble;
        }

        // PUT: api/Inmuebles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInmueble(string id, Inmueble inmueble)
        {
            if (id != inmueble.MatriculaInmobiliariaInmueble)
            {
                return BadRequest();
            }

            _context.Entry(inmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExists(id))
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

        // POST: api/Inmuebles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inmueble>> PostInmueble(Inmueble inmueble)
        {
          if (_context.Inmuebles == null)
          {
              return Problem("Entity set 'CrMercantilContext.Inmuebles'  is null.");
          }
            _context.Inmuebles.Add(inmueble);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InmuebleExists(inmueble.MatriculaInmobiliariaInmueble))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInmueble", new { id = inmueble.MatriculaInmobiliariaInmueble }, inmueble);
        }

        // DELETE: api/Inmuebles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInmueble(string id)
        {
            if (_context.Inmuebles == null)
            {
                return NotFound();
            }
            var inmueble = await _context.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            _context.Inmuebles.Remove(inmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InmuebleExists(string id)
        {
            return (_context.Inmuebles?.Any(e => e.MatriculaInmobiliariaInmueble == id)).GetValueOrDefault();
        }
    }
}
