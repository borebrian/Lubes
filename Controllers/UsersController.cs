using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lubes.DBContext;
using Lubes.Models;
using Microsoft.AspNetCore.Http;

namespace Lubes.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.c_Users.ToListAsync());
        }
            
      

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.c_Users
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Roles") == "1" || HttpContext.Session.GetString("Roles") == "3")
            {

               

            }
            else
            {
                TempData["warn"] = "You dont have previlleges to access this link!";
                return Redirect("~/Administration/Dashboard");

            }
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Full_name,Phone,Password,National_id,strRole")] Users users)
        {
            var x = HttpContext.Session.GetString("Username");

            if (x == null)
            {
                return Redirect("~/Home/Log_in");

            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(users);
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var x = HttpContext.Session.GetString("Username");

            if (x == null)
            {
                return Redirect("~/Home/Log_in");

            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }

                var users = await _context.c_Users.FindAsync(id);
                if (users == null)
                {
                    return NotFound();
                }
                return View(users);
            }
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Full_name,Phone,Password,National_id,strRole")] Users users)
        {
            var x = HttpContext.Session.GetString("Username");

            if (x == null)
            {
                return Redirect("~/Home/Log_in");

            }
            else
            {
                if (id != users.National_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(users);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsersExists(users.National_id))
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
                return View(users);
            }
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.c_Users
                .FirstOrDefaultAsync(m => m.National_id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.c_Users.FindAsync(id);
            _context.c_Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.c_Users.Any(e => e.National_id == id);
        }
    }
}
