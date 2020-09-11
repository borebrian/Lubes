using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fuela.DBContext;

using Microsoft.AspNetCore.Authorization;
using Lubes.Models;
using Lubes.DBContext;

namespace Lubes.Controllers
{
    public class c_UsersController : Controller
    {
        private readonly ApplicationDBContext _context;

        public c_UsersController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: c_Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.c_Users.ToListAsync());
        }

        // GET: c_Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c_Users = await _context.c_Users
                .FirstOrDefaultAsync(m => m.strUserId == id);
            if (c_Users == null)
            {
                return NotFound();
            }

            return View(c_Users);
        }

        // GET: c_Users/Create
      
        public IActionResult Create()
        {
          
            
            List<Roles> CategoryList = new List<Roles>();
            CategoryList = (from items in _context.Roles select items).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})
            CategoryList.Insert(0, new Roles { Role_id = 0, Role_name = "--Select role--" });
            ViewBag.categoryList = CategoryList;
            return View();
             
        }

        // POST: c_Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Full_name,strPhone,strPassword,strUserId,strRole")] c_Users c_Users)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c_Users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            List<Roles> CategoryList = new List<Roles>();
            CategoryList = (from items in _context.Roles select items).ToList();
            //idList.Insert(0, new Rental_Owners { National_id=0,Full_names})
            CategoryList.Insert(0, new Roles { Role_id = 0, Role_name = "--Select role--" });
            ViewBag.categoryList = CategoryList;
            return View(c_Users);
        }

        // GET: c_Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c_Users = await _context.c_Users.FindAsync(id);
            if (c_Users == null)
            {
                return NotFound();
            }
            return View(c_Users);
        }

        // POST: c_Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("strPhone,strDOB,strEmail,strPassword,strUserId,strRole")] c_Users c_Users)
        {
            if (id != c_Users.strUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c_Users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!c_UsersExists(c_Users.strUserId))
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
            return View(c_Users);
        }

        // GET: c_Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c_Users = await _context.c_Users
                .FirstOrDefaultAsync(m => m.strUserId == id);
            if (c_Users == null)
            {
                return NotFound();
            }

            return View(c_Users);
        }

        // POST: c_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var c_Users = await _context.c_Users.FindAsync(id);
            _context.c_Users.Remove(c_Users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool c_UsersExists(string id)
        {
            return _context.c_Users.Any(e => e.strUserId == id);
        }
    }
}
