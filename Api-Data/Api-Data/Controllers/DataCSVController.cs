using Api_Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataCSVController : ControllerBase
    {
        // GET: api/<DataCSVController>
        private readonly MyDBContext _context;
        public DataCSVController(MyDBContext context)
        {
            _context = context;
        }

        // GET api/<DataCSVController>/5
        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<DataCSV>>> GetData()
        {
            return await _context.dataCSVs.ToListAsync();
        }

        [HttpGet]
        [Route("Get-Id/{id}")]

        public async Task<ActionResult<DataCSV>> GetData(int id)
        {
            var data = await _context.dataCSVs.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }
        [HttpGet]
        [Route("Get-Eissn/{eissn}")]
        public async Task<ActionResult<DataCSV>> GetData(string eissn)
        {
            var data = await _context.dataCSVs.Where(b => b.eissn == eissn).FirstOrDefaultAsync();

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }
    }
}
