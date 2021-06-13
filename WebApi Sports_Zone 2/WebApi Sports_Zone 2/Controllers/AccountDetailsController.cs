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
    public class AccountDetailsController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public AccountDetailsController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/AccountDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDetails>>> GetAccountDetails()
        {
            return await _context.AccountDetails.ToListAsync();
        }

        // GET: api/AccountDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetails>> GetAccountDetails(string id)
        {
            var accountDetails = await _context.AccountDetails.FindAsync(id);

            if (accountDetails == null)
            {
                return NotFound();
            }

            return accountDetails;
        }

        // PUT: api/AccountDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountDetails(string id, AccountDetails accountDetails)
        {
            if (id != accountDetails.AccName)
            {
                return BadRequest();
            }

            _context.Entry(accountDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountDetailsExists(id))
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

        // POST: api/AccountDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountDetails>> PostAccountDetails(AccountDetails accountDetails)
        {
            _context.AccountDetails.Add(accountDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountDetailsExists(accountDetails.AccName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccountDetails", new { id = accountDetails.AccName }, accountDetails);
        }

        // DELETE: api/AccountDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountDetails>> DeleteAccountDetails(string id)
        {
            var accountDetails = await _context.AccountDetails.FindAsync(id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            _context.AccountDetails.Remove(accountDetails);
            await _context.SaveChangesAsync();

            return accountDetails;
        }

        private bool AccountDetailsExists(string id)
        {
            return _context.AccountDetails.Any(e => e.AccName == id);
        }
    }
}
