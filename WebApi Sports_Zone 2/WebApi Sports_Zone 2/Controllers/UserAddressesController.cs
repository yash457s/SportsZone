using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Sports_Zone_2.Models;

namespace WebApi_Sports_Zone_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public UserAddressesController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/UserAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAddresses>>> GetUserAddresses()
        {
            return await _context.UserAddresses.ToListAsync();
        }

        // GET: api/UserAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAddresses>> GetUserAddresses(string id)
        {
            var userAddresses = await _context.UserAddresses.FindAsync(id);

            if (userAddresses == null)
            {
                return NotFound();
            }

            return userAddresses;
        }

        // PUT: api/UserAddresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAddresses(string id, UserAddresses userAddresses)
        {
            if (id != userAddresses.Username)
            {
                return BadRequest();
            }

            _context.Entry(userAddresses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressesExists(id))
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

        // POST: api/UserAddresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserAddresses>> PostUserAddresses(UserAddresses userAddresses)
        {
            _context.UserAddresses.Add(userAddresses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAddressesExists(userAddresses.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAddresses", new { id = userAddresses.Username }, userAddresses);
        }

        // DELETE: api/UserAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAddresses>> DeleteUserAddresses(string id)
        {
            var userAddresses = await _context.UserAddresses.FindAsync(id);
            if (userAddresses == null)
            {
                return NotFound();
            }

            _context.UserAddresses.Remove(userAddresses);
            await _context.SaveChangesAsync();

            return userAddresses;
        }

        private bool UserAddressesExists(string id)
        {
            return _context.UserAddresses.Any(e => e.Username == id);
        }
    }
}
