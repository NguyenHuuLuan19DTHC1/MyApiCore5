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
    public class SinhViensController : ControllerBase
    {
        private readonly MyDBContext _context;

        public SinhViensController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/SinhViens
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
        {
            return await _context.SinhViens.ToListAsync();
        }

        // GET: api/SinhViens/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);

            if (sinhVien == null)
            {
                return NotFound();
            }

            return sinhVien;
        }

        // PUT: api/SinhViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutSinhVien(string id, SinhVien sinhVien)
        {
            if (id != sinhVien.MSSV)
            {
                return BadRequest();
            }

            _context.Entry(sinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhVienExists(id))
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

        // POST: api/SinhViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SinhVienExists(sinhVien.MSSV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSinhVien", new { id = sinhVien.MSSV }, sinhVien);
        }

        // DELETE: api/SinhViens/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteSinhVien(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            _context.SinhViens.Remove(sinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhViens.Any(e => e.MSSV == id);
        }
    }
}
