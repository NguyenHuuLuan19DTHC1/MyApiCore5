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
    public class ChungNhansController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ChungNhansController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/ChungNhans
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<ChungNhan>>> GetChungNhans()
        {
            return await _context.ChungNhans.ToListAsync();
        }

        // GET: api/ChungNhans/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<ChungNhan>> GetChungNhan(string id)
        {
            var chungNhan = await _context.ChungNhans.FindAsync(id);

            if (chungNhan == null)
            {
                return NotFound();
            }

            return chungNhan;
        }

        // PUT: api/ChungNhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutChungNhan(string id, ChungNhan chungNhan)
        {
            if (id != chungNhan.IDChungNhan)
            {
                return BadRequest();
            }

            _context.Entry(chungNhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChungNhanExists(id))
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

        // POST: api/ChungNhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ChungNhan>> PostChungNhan(ChungNhan chungNhan)
        {
            _context.ChungNhans.Add(chungNhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChungNhanExists(chungNhan.IDChungNhan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChungNhan", new { id = chungNhan.IDChungNhan }, chungNhan);
        }

        // DELETE: api/ChungNhans/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteChungNhan(string id)
        {
            var chungNhan = await _context.ChungNhans.FindAsync(id);
            if (chungNhan == null)
            {
                return NotFound();
            }

            _context.ChungNhans.Remove(chungNhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChungNhanExists(string id)
        {
            return _context.ChungNhans.Any(e => e.IDChungNhan == id);
        }
    }
}
