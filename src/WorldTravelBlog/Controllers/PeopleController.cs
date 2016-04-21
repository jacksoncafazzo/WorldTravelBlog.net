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
                person.Experiences = _context.Experiences.Join(_context.ExperiencePeople.Where(m => m.PersonId == id).ToList(), m => m.ExperienceId, m => m.ExperienceId, (o, i) => o).ToList();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Hangout(int PersonId, int experienceId)
        {
            ExperiencePerson hangout = new ExperiencePerson();
            hangout.PersonId = PersonId;
            hangout.ExperienceId = experienceId;
            _context.ExperiencePeople.Add(hangout);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { id = PersonId });
        }

        // GET: People/Create
        public IActionResult Create(string returnUrl = null)
        {
            if (returnUrl == null)
            {
                returnUrl = "/People/";
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else return RedirectToAction("Index");
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

            Person person = _context.People.FirstOrDefault(m => m.PersonId == id);

            person.Experiences = _context.Experiences.Join(_context.ExperiencePeople.Where(m => m.PersonId == id).ToList(), m => m.ExperienceId, m => m.ExperienceId, (o, i) => o).ToList();

            ViewBag.Experiences = _context.Experiences.ToList().Except(person.Experiences);
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