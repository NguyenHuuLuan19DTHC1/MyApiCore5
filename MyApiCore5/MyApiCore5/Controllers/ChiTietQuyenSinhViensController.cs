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
    public class ChiTietQuyenSinhViensController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ChiTietQuyenSinhViensController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietQuyenSinhViens
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<ChiTietQuyenSinhVien>>> GetChiTietQuyenSinhViens()
        {
            return await _context.ChiTietQuyenSinhViens.ToListAsync();
        }

        // GET: api/ChiTietQuyenSinhViens/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<ChiTietQuyenSinhVien>> GetChiTietQuyenSinhVien(string id)
        {
            var chiTietQuyenSinhVien = await _context.ChiTietQuyenSinhViens.FindAsync(id);

            if (chiTietQuyenSinhVien == null)
            {
                return NotFound();
            }

            return chiTietQuyenSinhVien;
        }

        // PUT: api/ChiTietQuyenSinhViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutChiTietQuyenSinhVien(string id, ChiTietQuyenSinhVien chiTietQuyenSinhVien)
        {
            if (id != chiTietQuyenSinhVien.MSSV)
            {
                return BadRequest();
            }

            _context.Entry(chiTietQuyenSinhVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietQuyenSinhVienExists(id))
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

        // POST: api/ChiTietQuyenSinhViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ChiTietQuyenSinhVien>> PostChiTietQuyenSinhVien(ChiTietQuyenSinhVien chiTietQuyenSinhVien)
        {
            _context.ChiTietQuyenSinhViens.Add(chiTietQuyenSinhVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietQuyenSinhVienExists(chiTietQuyenSinhVien.MSSV))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietQuyenSinhVien", new { id = chiTietQuyenSinhVien.MSSV }, chiTietQuyenSinhVien);
        }

        // DELETE: api/ChiTietQuyenSinhViens/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteChiTietQuyenSinhVien(string id)
        {
            var chiTietQuyenSinhVien = await _context.ChiTietQuyenSinhViens.FindAsync(id);
            if (chiTietQuyenSinhVien == null)
            {
                return NotFound();
            }

            _context.ChiTietQuyenSinhViens.Remove(chiTietQuyenSinhVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietQuyenSinhVienExists(string id)
        {
            return _context.ChiTietQuyenSinhViens.Any(e => e.MSSV == id);
        }
    }
}
