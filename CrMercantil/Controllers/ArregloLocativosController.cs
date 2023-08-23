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
    public class ArregloLocativosController : ControllerBase
    {
        private readonly CrMercantilContext _context;

        public ArregloLocativosController(CrMercantilContext context)
        {
            _context = context;
        }

        // GET: api/ArregloLocativoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArregloLocativo>>> GetArregloLocativos()
        {
          if (_context.ArregloLocativos == null)
          {
              return NotFound();
          }
            return await _context.ArregloLocativos.ToListAsync();
        }

        // GET: api/ArregloLocativoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArregloLocativo>> GetArregloLocativo(int id)
        {
          if (_context.ArregloLocativos == null)
          {
              return NotFound();
          }
            var arregloLocativo = await _context.ArregloLocativos.FindAsync(id);

            if (arregloLocativo == null)
            {
                return NotFound();
            }

            return arregloLocativo;
        }

        // PUT: api/ArregloLocativoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArregloLocativo(int id, ArregloLocativo arregloLocativo)
        {
            if (id != arregloLocativo.IdLocativaArreglo)
            {
                return BadRequest();
            }

            _context.Entry(arregloLocativo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArregloLocativoExists(id))
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

        // POST: api/ArregloLocativoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArregloLocativo>> PostArregloLocativo(ArregloLocativo arregloLocativo)
        {
          if (_context.ArregloLocativos == null)
          {
              return Problem("Entity set 'CrMercantilContext.ArregloLocativos'  is null.");
          }
            _context.ArregloLocativos.Add(arregloLocativo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArregloLocativoExists(arregloLocativo.IdLocativaArreglo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArregloLocativo", new { id = arregloLocativo.IdLocativaArreglo }, arregloLocativo);
        }

        // DELETE: api/ArregloLocativoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArregloLocativo(int id)
        {
            if (_context.ArregloLocativos == null)
            {
                return NotFound();
            }
            var arregloLocativo = await _context.ArregloLocativos.FindAsync(id);
            if (arregloLocativo == null)
            {
                return NotFound();
            }

            _context.ArregloLocativos.Remove(arregloLocativo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArregloLocativoExists(int id)
        {
            return (_context.ArregloLocativos?.Any(e => e.IdLocativaArreglo == id)).GetValueOrDefault();
        }
    }
}
