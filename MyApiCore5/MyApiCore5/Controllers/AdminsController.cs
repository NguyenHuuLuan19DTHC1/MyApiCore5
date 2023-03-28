using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiCore5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApiCore5.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly MyDBContext _context;
        public AdminsController(MyDBContext context)
        {
            _context = context;

        }
        [HttpGet]
        [Route("Get-all")]

        public async Task<ActionResult<IEnumerable<Admin>>> GetAll()
        {
            try
            {
                return Ok(await _context.Admins.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Route("login/{IDAdmin},{Password}")]
        [HttpGet]
        [Route(("Login/{IDAdmin},{Password}"))]

        public bool LoginAdmin(string IDAdmin, string Password)
        {
            try
            {
                /*var a=await _context.Admins.FirstOrDefaultAsync(ad=>(ad.IDAdmin==IDAdmin) && ad.Password==Password);*/
                var q = from p in _context.Admins

                        where p.IDAdmin == IDAdmin

                        && p.Password == Password

                        select p;

                if (q.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
        {
            try
            {
                _context.Admins!.Add(admin);
                await _context.SaveChangesAsync();

                return CreatedAtAction("LoginAdmin", new { IDAdmin = admin.IDAdmin, Password = admin.Password }, admin);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin(string id)
        {
            var Ad = await _context.Admins!.FindAsync(id);
            if (Ad == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(Ad);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool AdminExists(string id)
        {
            return _context.Admins!.Any(e => e.IDAdmin == id);
        }
        [Route("Update/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutAdmin(string id, Admin admin)
        {
            if (id != admin.IDAdmin)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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
    }
}
