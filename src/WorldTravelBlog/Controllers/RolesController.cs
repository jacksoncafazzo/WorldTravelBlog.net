using System.Collections.Generic;
using System.Linq;
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

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View("Index", _context.Roles.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(FormCollection collection)
        {
            _context.Roles.Add(new IdentityRole(Request.Form["RoleName"]));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(m => m.Name == roleName);
            if (role != null)
            {
                try
                {
                    _context.Roles.Remove(role);
                    _context.SaveChanges();
                }
                catch
                {
                    ViewData["message"] = "Users still in role " + roleName;
                    return Index();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Assign()
        {
            ViewBag.Users = new SelectList(_userManager.Users.ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRoles(string user)
        {
            var usera = GetUser(user);
            ViewBag.User = usera;
            var userRoles = _userManager.GetRolesAsync(usera).Result;
            ViewBag.RolesForThisUser = userRoles;
            var preroles = _context.Roles.ToList();
            var roles = new List<string>();
            foreach (var r in preroles)
            {
                var add = true;
                foreach (var userRole in userRoles)
                {
                    if (userRole == r.Name)
                    {
                        add = false;
                    }
                }
                if (add)
                {
                    roles.Add(r.Name);
                }
            }
            ViewBag.Users = new SelectList(_userManager.Users.ToList());
            ViewBag.Roles = roles;
            return View("Assign");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddToUser(string username, string roleName)
        {
            var user = GetUser(username);
            var thing = _userManager.AddToRoleAsync(user, roleName).Result;
            return GetRoles(username);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFromUser(string username, string roleName)
        {
            var thing = _userManager.RemoveFromRoleAsync(GetUser(username), roleName).Result;
            return GetRoles(username);
        }

        [Authorize(Roles = "Admin")]
        public ApplicationUser GetUser(string username)
        {
            return _userManager.Users.FirstOrDefault(m => m.UserName == username);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string roleName)
        {
            ViewData["roleName"] = roleName;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit()
        {
            var role = _context.Roles.FirstOrDefault(m => m.Name == Request.Form["role-name"]);
            role.Name = Request.Form["edit-role"];
            _context.Roles.Update(role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}