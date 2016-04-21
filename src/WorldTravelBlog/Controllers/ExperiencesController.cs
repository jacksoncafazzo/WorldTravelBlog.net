using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Routing;
using System.Linq;
using System.Security.Claims;
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
            return checkLogin(View(_context.Experiences.ToList()));
        }

        // GET: Experiences/Details/5
        public IActionResult Details(int? id)
        {
            Experience experience = _context.Experiences.FirstOrDefault(m => m.ExperienceId == id);
            experience.Locations = _context.Locations.Join(_context.ExperienceLocations.Where(m => m.ExperienceId == id).ToList(),
                m => m.LocationId,
                m => m.LocationId,
                (o, i) => o).ToList();
            experience.People = _context.People.Join(_context.ExperiencePeople.Where(m => m.ExperienceId == id).ToList(),
                m => m.PersonId,
                m => m.PersonId,
                (o, i) => o).ToList();

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        //P POST: Experiences/Event
        [HttpPost, ActionName("Event")]
        public IActionResult Event(int experienceId, int locationId)
        {
            ExperienceLocation Event = new ExperienceLocation();
            Event.LocationId = locationId;
            Event.ExperienceId = experienceId;
            _context.ExperienceLocations.Add(Event);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = experienceId });
        }

        [HttpPost]
        public IActionResult RemoveEvent(int experienceId, int locationId)
        {
            ExperienceLocation Event = _context.ExperienceLocations.FirstOrDefault(m => m.ExperienceId == experienceId && m.LocationId == locationId);
            _context.ExperienceLocations.Remove(Event);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = experienceId });
        }

        [HttpPost]
        public IActionResult Happening(int experienceId, int personId)
        {
            ExperiencePerson happening = new ExperiencePerson();
            happening.ExperienceId = experienceId;
            happening.PersonId = personId;
            _context.ExperiencePeople.Add(happening);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = experienceId });
        }

        [HttpPost]
        public IActionResult RemoveHappening(int experienceId, int personId)
        {
            ExperiencePerson happening = _context.ExperiencePeople.FirstOrDefault(m => m.ExperienceId == experienceId && m.PersonId == personId);
            _context.ExperiencePeople.Remove(happening);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = experienceId });
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
        public IActionResult Edit(int id)
        {
            Experience experience = _context.Experiences.FirstOrDefault(m => m.ExperienceId == id);

            experience.Locations = _context.Locations.Join(
                _context.ExperienceLocations.Where(m => m.ExperienceId == id).ToList(),
                m => m.LocationId,
                m => m.LocationId,
                (o, i) => o).ToList();

            experience.People = _context.People.Join(_context.ExperiencePeople.Where(m => m.ExperienceId == id).ToList(), m => m.PersonId, m => m.PersonId, (o, i) => o).ToList();
            ViewBag.Locations = _context.Locations.ToList().Except(experience.Locations);
            ViewBag.People = _context.People.ToList().Except(experience.People);
            ViewData["ReturnUrl"] = "/Experiences/Edit/" + id;
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
            return checkLogin(View(experience));
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

            return checkLogin(View(experience));
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Experience experience = _context.Experiences.Single(m => m.ExperienceId == id);
            _context.Experiences.Remove(experience);
            _context.SaveChanges();
            return checkLogin(RedirectToAction("Index"));
        }

        [NonAction]
        private IActionResult checkLogin(IActionResult action)
        {
            if (User.IsSignedIn())
                return action;
            else return RedirectToAction("Login", "Account");
        }
    }
}