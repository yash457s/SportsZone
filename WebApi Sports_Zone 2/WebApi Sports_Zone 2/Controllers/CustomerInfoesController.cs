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
    public class CustomerInfoesController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public CustomerInfoesController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerInfo>>> GetCustomerInfo()
        {
            return await _context.CustomerInfo.ToListAsync();
        }

        // GET: api/CustomerInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerInfo>> GetCustomerInfo(string id)
        {
            var customerInfo = await _context.CustomerInfo.FindAsync(id);

            if (customerInfo == null)
            {
                return NotFound();
            }

            return customerInfo;
        }

        // PUT: api/CustomerInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerInfo(string id, CustomerInfo customerInfo)
        {
            if (id != customerInfo.CusId)
            {
                return BadRequest();
            }

            _context.Entry(customerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInfoExists(id))
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

        // POST: api/CustomerInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerInfo>> PostCustomerInfo(CustomerInfo customerInfo)
        {
            _context.CustomerInfo.Add(customerInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerInfoExists(customerInfo.CusId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerInfo", new { id = customerInfo.CusId }, customerInfo);
        }

        // DELETE: api/CustomerInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerInfo>> DeleteCustomerInfo(string id)
        {
            var customerInfo = await _context.CustomerInfo.FindAsync(id);
            if (customerInfo == null)
            {
                return NotFound();
            }

            _context.CustomerInfo.Remove(customerInfo);
            await _context.SaveChangesAsync();

            return customerInfo;
        }

        private bool CustomerInfoExists(string id)
        {
            return _context.CustomerInfo.Any(e => e.CusId == id);
        }
    }
}
