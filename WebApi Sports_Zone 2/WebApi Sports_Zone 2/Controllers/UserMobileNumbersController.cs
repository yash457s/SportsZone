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
    public class UserMobileNumbersController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public UserMobileNumbersController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/UserMobileNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMobileNumbers>>> GetUserMobileNumbers()
        {
            return await _context.UserMobileNumbers.ToListAsync();
        }

        // GET: api/UserMobileNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMobileNumbers>> GetUserMobileNumbers(string id)
        {
            var userMobileNumbers = await _context.UserMobileNumbers.FindAsync(id);

            if (userMobileNumbers == null)
            {
                return NotFound();
            }

            return userMobileNumbers;
        }

        // PUT: api/UserMobileNumbers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMobileNumbers(string id, UserMobileNumbers userMobileNumbers)
        {
            if (id != userMobileNumbers.Username)
            {
                return BadRequest();
            }

            _context.Entry(userMobileNumbers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMobileNumbersExists(id))
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

        // POST: api/UserMobileNumbers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserMobileNumbers>> PostUserMobileNumbers(UserMobileNumbers userMobileNumbers)
        {
            _context.UserMobileNumbers.Add(userMobileNumbers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserMobileNumbersExists(userMobileNumbers.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserMobileNumbers", new { id = userMobileNumbers.Username }, userMobileNumbers);
        }

        // DELETE: api/UserMobileNumbers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserMobileNumbers>> DeleteUserMobileNumbers(string id)
        {
            var userMobileNumbers = await _context.UserMobileNumbers.FindAsync(id);
            if (userMobileNumbers == null)
            {
                return NotFound();
            }

            _context.UserMobileNumbers.Remove(userMobileNumbers);
            await _context.SaveChangesAsync();

            return userMobileNumbers;
        }

        private bool UserMobileNumbersExists(string id)
        {
            return _context.UserMobileNumbers.Any(e => e.Username == id);
        }
    }
}
