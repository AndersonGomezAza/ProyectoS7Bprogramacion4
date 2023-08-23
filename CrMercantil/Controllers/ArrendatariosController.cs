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
    public class ArrendatariosController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public ArrendatariosController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/Arrendatarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arrendatario>>> GetArrendatarios()
        {
          if (_context.Arrendatarios == null)
          {
              return NotFound();
          }
            return await _context.Arrendatarios.ToListAsync();
        }

        // GET: api/Arrendatarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arrendatario>> GetArrendatario(int id)
        {
          if (_context.Arrendatarios == null)
          {
              return NotFound();
          }
            var arrendatario = await _context.Arrendatarios.FindAsync(id);

            if (arrendatario == null)
            {
                return NotFound();
            }

            return arrendatario;
        }

        // PUT: api/Arrendatarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrendatario(int id, Arrendatario arrendatario)
        {
            if (id != arrendatario.CedulaArrendatario)
            {
                return BadRequest();
            }

            _context.Entry(arrendatario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArrendatarioExists(id))
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

        // POST: api/Arrendatarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arrendatario>> PostArrendatario(Arrendatario arrendatario)
        {
          if (_context.Arrendatarios == null)
          {
              return Problem("Entity set 'CrMercantilContext.Arrendatarios'  is null.");
          }
            _context.Arrendatarios.Add(arrendatario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArrendatarioExists(arrendatario.CedulaArrendatario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArrendatario", new { id = arrendatario.CedulaArrendatario }, arrendatario);
        }

        // DELETE: api/Arrendatarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrendatario(int id)
        {
            if (_context.Arrendatarios == null)
            {
                return NotFound();
            }
            var arrendatario = await _context.Arrendatarios.FindAsync(id);
            if (arrendatario == null)
            {
                return NotFound();
            }

            _context.Arrendatarios.Remove(arrendatario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArrendatarioExists(int id)
        {
            return (_context.Arrendatarios?.Any(e => e.CedulaArrendatario == id)).GetValueOrDefault();
        }
    }
}
