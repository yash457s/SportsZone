using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsZone2.Models;

namespace SportsZone2.Controllers
{
    public class AccountDetailsController : Controller
    {
        private readonly Sports_Zone_DbContext _context;

        public AccountDetailsController(Sports_Zone_DbContext context)
        {
            _context = context;
        }

        // GET: AccountDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountDetails.ToListAsync());
        }

        // GET: AccountDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetails = await _context.AccountDetails
                .FirstOrDefaultAsync(m => m.AccName == id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            return View(accountDetails);
        }

        // GET: AccountDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccName,AccPassword,AccPhone,AccAddress,AccEmail")] AccountDetails accountDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountDetails);
        }

        // GET: AccountDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetails = await _context.AccountDetails.FindAsync(id);
            if (accountDetails == null)
            {
                return NotFound();
            }
            return View(accountDetails);
        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccName,AccPassword,AccPhone,AccAddress,AccEmail")] AccountDetails accountDetails)
        {
            if (id != accountDetails.AccName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountDetailsExists(accountDetails.AccName))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accountDetails);
        }

        // GET: AccountDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetails = await _context.AccountDetails
                .FirstOrDefaultAsync(m => m.AccName == id);
            if (accountDetails == null)
            {
                return NotFound();
            }

            return View(accountDetails);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountDetails = await _context.AccountDetails.FindAsync(id);
            _context.AccountDetails.Remove(accountDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountDetailsExists(string id)
        {
            return _context.AccountDetails.Any(e => e.AccName == id);
        }
    }
}
