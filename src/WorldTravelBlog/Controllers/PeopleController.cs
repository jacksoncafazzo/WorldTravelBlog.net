using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WorldTravelBlog.Models;

namespace WorldTravelBlog.Controllers
{
    public class PeopleController : Controller
    {
        private WorldTravelDbContext _context;

        public PeopleController(WorldTravelDbContext context)
        {
            _context = context;    
        }

        // GET: People
        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        // GET: People/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.PersonId == id);
            person.Locations = _context.Locations.Join(_context.LocationPeople.Where(m => m.PersonId == id).ToList(), m => m.LocationId, m => m.LocationId, (o, i) => o).ToList();
            person.Experiences = _context.Experiences.Join(_context.ExperiencePeople.Where(m => m.PersonId == id).ToList(), m => m.ExperienceId, m => m.ExperienceId, (o, i) => o).ToList();
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.Locations = _context.Locations.ToList();
            ViewBag.Experiences = _context.Experiences.ToList();

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.PersonId == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.PersonId == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Person person = _context.People.Single(m => m.PersonId == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
