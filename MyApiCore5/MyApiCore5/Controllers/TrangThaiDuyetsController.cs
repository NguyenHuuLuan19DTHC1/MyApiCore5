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
    public class TrangThaiDuyetsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public TrangThaiDuyetsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/TrangThaiDuyets
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<TrangThaiDuyet>>> GetTrangThaiDuyets()
        {
            return await _context.TrangThaiDuyets.ToListAsync();
        }

        // GET: api/TrangThaiDuyets/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<TrangThaiDuyet>> GetTrangThaiDuyet(string id)
        {
            var trangThaiDuyet = await _context.TrangThaiDuyets.FindAsync(id);

            if (trangThaiDuyet == null)
            {
                return NotFound();
            }

            return trangThaiDuyet;
        }

        // PUT: api/TrangThaiDuyets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutTrangThaiDuyet(string id, TrangThaiDuyet trangThaiDuyet)
        {
            if (id != trangThaiDuyet.IDTrangThai)
            {
                return BadRequest();
            }

            _context.Entry(trangThaiDuyet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrangThaiDuyetExists(id))
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

        // POST: api/TrangThaiDuyets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<TrangThaiDuyet>> PostTrangThaiDuyet(TrangThaiDuyet trangThaiDuyet)
        {
            _context.TrangThaiDuyets.Add(trangThaiDuyet);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrangThaiDuyetExists(trangThaiDuyet.IDTrangThai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrangThaiDuyet", new { id = trangThaiDuyet.IDTrangThai }, trangThaiDuyet);
        }

        // DELETE: api/TrangThaiDuyets/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteTrangThaiDuyet(string id)
        {
            var trangThaiDuyet = await _context.TrangThaiDuyets.FindAsync(id);
            if (trangThaiDuyet == null)
            {
                return NotFound();
            }

            _context.TrangThaiDuyets.Remove(trangThaiDuyet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrangThaiDuyetExists(string id)
        {
            return _context.TrangThaiDuyets.Any(e => e.IDTrangThai == id);
        }
    }
}
