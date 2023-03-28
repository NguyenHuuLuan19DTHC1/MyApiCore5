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
    public class ChiTietQuyenAdminsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ChiTietQuyenAdminsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietQuyenAdmins
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<ChiTietQuyenAdmin>>> GetChiTietQuyenAdmins()
        {
            return await _context.ChiTietQuyenAdmins.ToListAsync();
        }

        // GET: api/ChiTietQuyenAdmins/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<ChiTietQuyenAdmin>> GetChiTietQuyenAdmin(string id)
        {
            var chiTietQuyenAdmin = await _context.ChiTietQuyenAdmins.FindAsync(id);

            if (chiTietQuyenAdmin == null)
            {
                return NotFound();
            }

            return chiTietQuyenAdmin;
        }

        // PUT: api/ChiTietQuyenAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutChiTietQuyenAdmin(string id, ChiTietQuyenAdmin chiTietQuyenAdmin)
        {
            if (id != chiTietQuyenAdmin.IDAdmin)
            {
                return BadRequest();
            }

            _context.Entry(chiTietQuyenAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietQuyenAdminExists(id))
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

        // POST: api/ChiTietQuyenAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ChiTietQuyenAdmin>> PostChiTietQuyenAdmin(ChiTietQuyenAdmin chiTietQuyenAdmin)
        {
            _context.ChiTietQuyenAdmins.Add(chiTietQuyenAdmin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietQuyenAdminExists(chiTietQuyenAdmin.IDAdmin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietQuyenAdmin", new { id = chiTietQuyenAdmin.IDAdmin }, chiTietQuyenAdmin);
        }

        // DELETE: api/ChiTietQuyenAdmins/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteChiTietQuyenAdmin(string id)
        {
            var chiTietQuyenAdmin = await _context.ChiTietQuyenAdmins.FindAsync(id);
            if (chiTietQuyenAdmin == null)
            {
                return NotFound();
            }

            _context.ChiTietQuyenAdmins.Remove(chiTietQuyenAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietQuyenAdminExists(string id)
        {
            return _context.ChiTietQuyenAdmins.Any(e => e.IDAdmin == id);
        }
    }
}
