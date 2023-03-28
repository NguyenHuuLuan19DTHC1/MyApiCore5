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
    public class QuyensController : ControllerBase
    {
        private readonly MyDBContext _context;

        public QuyensController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Quyens
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<Quyen>>> GetQuyens()
        {
            return await _context.Quyens.ToListAsync();
        }

        // GET: api/Quyens/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<Quyen>> GetQuyen(string id)
        {
            var quyen = await _context.Quyens.FindAsync(id);

            if (quyen == null)
            {
                return NotFound();
            }

            return quyen;
        }

        // PUT: api/Quyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutQuyen(string id, Quyen quyen)
        {
            if (id != quyen.IDQuyen)
            {
                return BadRequest();
            }

            _context.Entry(quyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenExists(id))
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

        // POST: api/Quyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Quyen>> PostQuyen(Quyen quyen)
        {
            _context.Quyens.Add(quyen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuyenExists(quyen.IDQuyen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuyen", new { id = quyen.IDQuyen }, quyen);
        }

        // DELETE: api/Quyens/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteQuyen(string id)
        {
            var quyen = await _context.Quyens.FindAsync(id);
            if (quyen == null)
            {
                return NotFound();
            }

            _context.Quyens.Remove(quyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuyenExists(string id)
        {
            return _context.Quyens.Any(e => e.IDQuyen == id);
        }
    }
}
