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
        private readonly ILogger<HomeController> _logger;

       

        //public IActionResult LoginUser(c_Users user)
        //{
           
            
        //    if (user.strUserId == null || user.strPassword == null)
        //    {
              
        //        TempData["Error"] = "Username or password required!";
        //        return Redirect("~/Home/Log_in");
        //    }
        //    var Username = user.strUserId;

        //    TokenProvider TokenProvider = new TokenProvider(_context);

        //    var userToken = TokenProvider.LoginUser(user.strUserId.ToString(), user.strPassword);
        //    if (userToken == null)
        //    {

          
        //        TempData["Error"] = "Incorrect username or passsword!";
        //        return Redirect("~/Home/Log_in");


        //    }

        //    HttpContext.Session.SetString("JWToken", userToken);
        //    HttpContext.Session.SetString("User", Username.ToString());
        //    return Redirect("~/Administration/Dashboard");

        //}
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");

        }
        public IActionResult Log_in([Optional] string
            err)

        {
            //var checkIfExist = _context.c_Users.ToList();
            //int countR = checkIfExist.Count();
            //if (countR ==0)
            //{
            //    Redirect("~/c_Users/Create");
            //}
            //@ViewBag.warning = err;

            return View();
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
