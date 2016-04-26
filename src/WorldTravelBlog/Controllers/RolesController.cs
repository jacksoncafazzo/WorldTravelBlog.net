using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
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
    }
}
