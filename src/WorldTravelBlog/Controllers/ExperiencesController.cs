using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        private WorldTravelDbContext _context;

        public ExperiencesController(WorldTravelDbContext context)
        {
            _context = context;    
        }

        // GET: Experiences
        public IActionResult Index()
        {
            return View(_context.Experiences.ToList());
        }

        // GET: Experiences/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Experience experience = _context.Experiences.Single(m => m.ExperienceId == id);
            if (experience == null)
            {
                return HttpNotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Experiences.Add(experience);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Experience experience = _context.Experiences.Single(m => m.ExperienceId == id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // POST: Experiences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Update(experience);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(experience);
        }

        // GET: Experiences/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Experience experience = _context.Experiences.Single(m => m.ExperienceId == id);
            if (experience == null)
            {
                return HttpNotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Experience experience = _context.Experiences.Single(m => m.ExperienceId == id);
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
