using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Roles.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FormCollection collection)
        {
            
            _context.Roles.Add(new IdentityRole(Request.Form["RoleName"]));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(m => m.Name == roleName);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Assign()
        {
            ViewBag.Users = new SelectList(_userManager.Users.ToList());

            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetRoles(string user)
        {
            var usera = GetUser(user);
            ViewBag.User = usera;
            ViewBag.RolesForThisUser = _userManager.GetRolesAsync(usera).Result;

            ViewBag.Users = new SelectList(_userManager.Users.ToList());
            ViewBag.Roles = new SelectList(_context.Roles.ToList());
            return View("Assign");
        }

        public IActionResult AddToUser(string username, string roleName)
        {
            var user = GetUser(username);
            var thing = _userManager.AddToRoleAsync(user, roleName).Result;
            return RedirectToAction("Assign");
        }

        public ApplicationUser GetUser(string username)
        {
            return _userManager.Users.FirstOrDefault(m => m.UserName == username);
        }
    }
}
