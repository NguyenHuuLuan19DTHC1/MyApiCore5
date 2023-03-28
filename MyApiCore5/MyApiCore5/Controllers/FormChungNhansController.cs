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
    public class FormChungNhansController : ControllerBase
    {
        private readonly MyDBContext _context;

        public FormChungNhansController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/FormChungNhans
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<FormChungNhan>>> GetFormChungNhans()
        {
            return await _context.FormChungNhans.ToListAsync();
        }

        // GET: api/FormChungNhans/5
        [HttpGet]
        [Route("Get-Id/{id}")]
        public async Task<ActionResult<FormChungNhan>> GetFormChungNhan(string id)
        {
            var formChungNhan = await _context.FormChungNhans.FindAsync(id);

            if (formChungNhan == null)
            {
                return NotFound();
            }

            return formChungNhan;
        }

        // PUT: api/FormChungNhans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutFormChungNhan(string id, FormChungNhan formChungNhan)
        {
            if (id != formChungNhan.IDForm)
            {
                return BadRequest();
            }

            _context.Entry(formChungNhan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormChungNhanExists(id))
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

        // POST: api/FormChungNhans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<FormChungNhan>> PostFormChungNhan(FormChungNhan formChungNhan)
        {
            _context.FormChungNhans.Add(formChungNhan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FormChungNhanExists(formChungNhan.IDForm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFormChungNhan", new { id = formChungNhan.IDForm }, formChungNhan);
        }

        // DELETE: api/FormChungNhans/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteFormChungNhan(string id)
        {
            var formChungNhan = await _context.FormChungNhans.FindAsync(id);
            if (formChungNhan == null)
            {
                return NotFound();
            }

            _context.FormChungNhans.Remove(formChungNhan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormChungNhanExists(string id)
        {
            return _context.FormChungNhans.Any(e => e.IDForm == id);
        }
    }
}
