using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController(DataContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAllUsers()
        {
            try
            {
                var users = await dbContext.Users.ToListAsync();
                if (users.Count > 0)
                    return users;
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUserByID(int id)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(id);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
