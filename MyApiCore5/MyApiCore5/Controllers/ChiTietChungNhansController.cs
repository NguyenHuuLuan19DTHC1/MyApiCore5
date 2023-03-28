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
    public class ChiTietChungNhansController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ChiTietChungNhansController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietChungNhans
        [HttpGet]
        [Route("Get-all")]

        public async Task<ActionResult<IEnumerable<ChiTietChungNhan>>> GetChiTietChungNhans()
        {
            return await _context.ChiTietChungNhans.ToListAsync();
        }

        // GET: api/ChiTietChungNhans/5
        [HttpGet]
        [Route("Get-Id/{id}")]

        public async Task<ActionResult<ChiTietChungNhan>> GetChiTietChungNhan(string id)
        {
            var chiTietChungNhan = await _context.ChiTietChungNhans.FindAsync(id);

            if (chiTietChungNhan == null)
            {
                return NotFound();
            }

            return chiTietChungNhan;
        }

        // PUT: api/ChiTietChungNhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> PutChiTietChungNhan(string id, ChiTietChungNhan chiTietChungNhan)
        {
            if (id != chiTietChungNhan.IDChiTietChungNhan)
            {
                return BadRequest();
            }

            _context.Entry(chiTietChungNhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietChungNhanExists(id))
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

        // POST: api/ChiTietChungNhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ChiTietChungNhan>> PostChiTietChungNhan(ChiTietChungNhan chiTietChungNhan)
        {
            _context.ChiTietChungNhans.Add(chiTietChungNhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietChungNhanExists(chiTietChungNhan.IDChiTietChungNhan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietChungNhan", new { id = chiTietChungNhan.IDChiTietChungNhan }, chiTietChungNhan);
        }

        // DELETE: api/ChiTietChungNhans/5
        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<IActionResult> DeleteChiTietChungNhan(string id)
        {
            var chiTietChungNhan = await _context.ChiTietChungNhans.FindAsync(id);
            if (chiTietChungNhan == null)
            {
                return NotFound();
            }

            _context.ChiTietChungNhans.Remove(chiTietChungNhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietChungNhanExists(string id)
        {
            return _context.ChiTietChungNhans.Any(e => e.IDChiTietChungNhan == id);
        }
    }
}
