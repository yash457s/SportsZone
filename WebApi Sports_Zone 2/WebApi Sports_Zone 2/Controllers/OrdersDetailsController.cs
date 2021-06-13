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
    public class OrdersDetailsController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public OrdersDetailsController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/OrdersDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersDetails>>> GetOrdersDetails()
        {
            return await _context.OrdersDetails.ToListAsync();
        }

        // GET: api/OrdersDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDetails>> GetOrdersDetails(string id)
        {
            var ordersDetails = await _context.OrdersDetails.FindAsync(id);

            if (ordersDetails == null)
            {
                return NotFound();
            }

            return ordersDetails;
        }

        // PUT: api/OrdersDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersDetails(string id, OrdersDetails ordersDetails)
        {
            if (id != ordersDetails.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(ordersDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersDetailsExists(id))
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

        // POST: api/OrdersDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrdersDetails>> PostOrdersDetails(OrdersDetails ordersDetails)
        {
            _context.OrdersDetails.Add(ordersDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdersDetailsExists(ordersDetails.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdersDetails", new { id = ordersDetails.OrderId }, ordersDetails);
        }

        // DELETE: api/OrdersDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersDetails>> DeleteOrdersDetails(string id)
        {
            var ordersDetails = await _context.OrdersDetails.FindAsync(id);
            if (ordersDetails == null)
            {
                return NotFound();
            }

            _context.OrdersDetails.Remove(ordersDetails);
            await _context.SaveChangesAsync();

            return ordersDetails;
        }

        private bool OrdersDetailsExists(string id)
        {
            return _context.OrdersDetails.Any(e => e.OrderId == id);
        }
    }
}
