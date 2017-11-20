using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tuto.Data;
using Tuto.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Tuto.UI.Controllers.Admin
{
    [Authorize]
    public class HomePageSettingsController : Controller
    {
        private readonly TutoContext _context;

        public HomePageSettingsController(TutoContext context)
        {
            _context = context;
        }

        // GET: HomePageSettings
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomePageSettings.ToListAsync());
        }

        // GET: HomePageSettings/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePageSettings = await _context.HomePageSettings
                .SingleOrDefaultAsync(m => m.Title == id);
            if (homePageSettings == null)
            {
                return NotFound();
            }

            return View(homePageSettings);
        }

        // GET: HomePageSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomePageSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Descritpion,SeoDescription")] HomePageSettings homePageSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homePageSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homePageSettings);
        }

        // GET: HomePageSettings/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePageSettings = await _context.HomePageSettings.SingleOrDefaultAsync(m => m.Title == id);
            if (homePageSettings == null)
            {
                return NotFound();
            }
            return View(homePageSettings);
        }

        // POST: HomePageSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Title,Descritpion,SeoDescription")] HomePageSettings homePageSettings)
        {
            if (id != homePageSettings.Title)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homePageSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageSettingsExists(homePageSettings.Title))
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
            return View(homePageSettings);
        }

        // GET: HomePageSettings/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homePageSettings = await _context.HomePageSettings
                .SingleOrDefaultAsync(m => m.Title == id);
            if (homePageSettings == null)
            {
                return NotFound();
            }

            return View(homePageSettings);
        }

        // POST: HomePageSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var homePageSettings = await _context.HomePageSettings.SingleOrDefaultAsync(m => m.Title == id);
            _context.HomePageSettings.Remove(homePageSettings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageSettingsExists(string id)
        {
            return _context.HomePageSettings.Any(e => e.Title == id);
        }
    }
}
