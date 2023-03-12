using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UngDungDocTruyen.Data;

namespace UngDungDocTruyen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly bookStoreContext _context;

        public usersController(bookStoreContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{MaUser}")]
        public async Task<ActionResult<user>> Getuser(string MaUser)
        {
            var user = await _context.users.FirstOrDefaultAsync(user => user.MaUser == MaUser);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{MaUser}")]
        public async Task<IActionResult> Putuser(string MaUser, user user)
        {
            if (MaUser != user.MaUser)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(MaUser))
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

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user>> Postuser(user user)
        {
            _context.users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (userExists(user.MaUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getuser", new { id = user.MaUser }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{MaUser}")]
        public async Task<IActionResult> Deleteuser(string MaUser)
        {
            var user = await _context.users.FirstOrDefaultAsync(user => user.MaUser == MaUser);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool userExists(string id)
        {
            return _context.users.Any(e => e.MaUser == id);
        }
    }
}
