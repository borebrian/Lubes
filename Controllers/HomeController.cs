using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Fuela.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Lubes.Models;
using Lubes.DBContext;

namespace Lubes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;
   

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
          
        }
     
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }
        public IActionResult Log_in()

        {
            HttpContext.Session.Clear();

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Log_in(Users users) { 
            var result = _context.c_Users.Where(i => i.National_id == users.National_id && i.Password == users.Password).FirstOrDefault();


            if (result != null)
            {
                HttpContext.Session.SetString("Roles", result.strRole.ToString());
                HttpContext.Session.SetString("Username", result.Full_name);
              return  Redirect("~/Administration/Dashboard");

            }
            else
            {
                ViewBag.Error = "Invalid log in credentials";
                //        return Redirect("~/Home/Log_in");

                return View();

            }


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
