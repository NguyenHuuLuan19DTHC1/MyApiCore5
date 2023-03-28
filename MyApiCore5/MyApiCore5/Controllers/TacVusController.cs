using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiCore5.Data;

namespace MyApiCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacVusController : ControllerBase
    {
        private readonly MyDBContext _context;

        public TacVusController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/TacVus
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<TacVu>>> GetTacVus()
        {
            return await _context.TacVus.ToListAsync();
        }

        // GET: api/TacVus/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<TacVu>> GetTacVu(string id)
        {
            var tacVu = await _context.TacVus.FindAsync(id);

            if (tacVu == null)
            {
                return NotFound();
            }

            return tacVu;
        }

        // PUT: api/TacVus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutTacVu(string id, TacVu tacVu)
        {
            if (id != tacVu.IDTacVu)
            {
                return BadRequest();
            }

            _context.Entry(tacVu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacVuExists(id))
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

        // POST: api/TacVus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<TacVu>> PostTacVu(TacVu tacVu)
        {
            _context.TacVus.Add(tacVu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TacVuExists(tacVu.IDTacVu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTacVu", new { id = tacVu.IDTacVu }, tacVu);
        }

        // DELETE: api/TacVus/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteTacVu(string id)
        {
            var tacVu = await _context.TacVus.FindAsync(id);
            if (tacVu == null)
            {
                return NotFound();
            }

            _context.TacVus.Remove(tacVu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacVuExists(string id)
        {
            return _context.TacVus.Any(e => e.IDTacVu == id);
        }
    }
}
