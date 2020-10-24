using System.Collections;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController 
    {

        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
                return await _context.Users.ToListAsync();
        }
          [HttpGet("{id}")]
          [Authorize]
          public async Task<ActionResult<AppUser>> GetUser(int id)
        {
                return await _context.Users.FindAsync(id);
        }
    }
}
