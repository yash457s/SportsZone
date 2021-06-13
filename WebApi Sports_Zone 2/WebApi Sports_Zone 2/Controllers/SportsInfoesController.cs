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
    public class SportsInfoesController : ControllerBase
    {
        private readonly Sports_Zone_DbContext _context;

        public SportsInfoesController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: api/SportsInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SportsInfo>>> GetSportsInfo()
        {
            return await _context.SportsInfo.ToListAsync();
        }

        // GET: api/SportsInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SportsInfo>> GetSportsInfo(string id)
        {
            var sportsInfo = await _context.SportsInfo.FindAsync(id);

            if (sportsInfo == null)
            {
                return NotFound();
            }

            return sportsInfo;
        }

        // PUT: api/SportsInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSportsInfo(string id, SportsInfo sportsInfo)
        {
            if (id != sportsInfo.SpoId)
            {
                return BadRequest();
            }

            _context.Entry(sportsInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportsInfoExists(id))
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

        // POST: api/SportsInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SportsInfo>> PostSportsInfo(SportsInfo sportsInfo)
        {
            _context.SportsInfo.Add(sportsInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SportsInfoExists(sportsInfo.SpoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSportsInfo", new { id = sportsInfo.SpoId }, sportsInfo);
        }

        // DELETE: api/SportsInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SportsInfo>> DeleteSportsInfo(string id)
        {
            var sportsInfo = await _context.SportsInfo.FindAsync(id);
            if (sportsInfo == null)
            {
                return NotFound();
            }

            _context.SportsInfo.Remove(sportsInfo);
            await _context.SaveChangesAsync();

            return sportsInfo;
        }

        private bool SportsInfoExists(string id)
        {
            return _context.SportsInfo.Any(e => e.SpoId == id);
        }
    }
}
