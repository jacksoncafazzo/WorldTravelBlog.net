using Microsoft.AspNet.Mvc;
using System.Linq;
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
        public IActionResult Details(int id)
        {
            Person person = _context.People.FirstOrDefault(m => m.PersonId == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Person" + person.Name + " ID " + id);
                var locations = _context.LocationPeople.Where(m => m.PersonId == id).ToList();
                person.Locations = _context.Locations.Join(
                    locations,
                    m => m.LocationId,
                    m => m.LocationId,
                    (o, i) => o)
                    .ToList();
                person.Experiences = _context.Experiences.Join(_context.ExperiencePeople.Where(m => m.PersonId == id).ToList(), m => m.ExperienceId, m => m.ExperienceId, (o, i) => o).ToList();
                ViewBag.Locations = _context.Locations.ToList().Except(person.Locations);
                ViewBag.Experiences = _context.Experiences.ToList().Except(person.Experiences);
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Relation(int PersonId, int locationId)
        {
            System.Diagnostics.Debug.WriteLine("locationId :" + locationId);

            LocationPerson relation = new LocationPerson();
            relation.LocationId = locationId;
            relation.PersonId = PersonId;
            _context.LocationPeople.Add(relation);

            _context.SaveChanges();
            return RedirectToAction("Details", new { id = PersonId });
        }

        [HttpPost]
        public IActionResult Hangout(int PersonId, int experienceId)
        {
            System.Diagnostics.Debug.WriteLine("experienceID :" + experienceId);
            ExperiencePerson hangout = new ExperiencePerson();
            hangout.PersonId = PersonId;
            hangout.ExperienceId = experienceId;
            _context.ExperiencePeople.Add(hangout);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = PersonId });
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