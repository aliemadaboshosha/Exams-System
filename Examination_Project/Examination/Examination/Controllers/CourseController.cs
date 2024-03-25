using Examination.Repos;
using Microsoft.AspNetCore.Mvc;
using Examination.Models;
using System.Threading.Tasks;

namespace Examination.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo _courseRepo;

        public CourseController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public IActionResult Index()
        {
            var courses = _courseRepo.GetAll();
            return View(courses);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _courseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            return View(course);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var course = _courseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            _courseRepo.Update(course);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var course = _courseRepo.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            _courseRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
