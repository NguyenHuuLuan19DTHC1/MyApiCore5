using Api_Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Data.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryDataController : ControllerBase
    {
        private readonly MyDBContext _context;
        public TemporaryDataController(MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<TemporaryData>>> GetTemporaryData()
        {
            return await _context.TemporaryDatas.ToListAsync();
        }

        [HttpGet]
        [Route("Get-Id/{id}")]

        public async Task<ActionResult<TemporaryData>> GetTemporaryData(int id)
        {
            var data = await _context.TemporaryDatas.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }
        [HttpPost]
        [Route("Send")]
        public async Task<ActionResult<TemporaryData>> PostTemporaryData(TemporaryData data)
        {
            _context.TemporaryDatas.Add(data);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                    return Conflict();

            }

            return CreatedAtAction("GetTemporaryData", new { id = data.number }, data);
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> PutTemporaryData( TemporaryData data)
        {
            /*if (id != data.number)
            {
                return BadRequest();
            }*/

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public async Task<IActionResult> DeleteTemporaryData(int id)
        {
            var data = await _context.TemporaryDatas.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.TemporaryDatas.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
