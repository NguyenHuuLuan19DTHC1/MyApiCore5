using Api_Data.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDBContext _context;
        public UsersController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route(("Login/{Username},{Password}"))]

        public bool Login(string Username, string Password)
        {
            try
            {
                /*var a=await _context.Admins.FirstOrDefaultAsync(ad=>(ad.IDAdmin==IDAdmin) && ad.Password==Password);*/
                var q = from p in _context.Users

                        where p.Username == Username

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
        public async Task<ActionResult<Users>> Create(Users users)
        {
            try
            {
                _context.Users!.Add(users);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Login", new { Username = users.Username, Password = users.Password }, users);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users!.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
