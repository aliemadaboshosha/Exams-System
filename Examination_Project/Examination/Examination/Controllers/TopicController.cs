using Examination.Repos;
using Microsoft.AspNetCore.Mvc;
using Examination.Models;
using System.Threading.Tasks;

namespace Examination.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicRepo _topicRepo;
        private readonly ICourseRepo _courseRepo;

        public TopicController(ITopicRepo topicRepo, ICourseRepo courseRepo)
        {
            _topicRepo = topicRepo;
            _courseRepo = courseRepo;
        }

        public IActionResult Index()
        {
            var topics = _topicRepo.GetAll();
            return View(topics);
        }

        public async Task< IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _topicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _courseRepo.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                _topicRepo.Add(topic);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            ViewBag.Courses = _courseRepo.GetAll();
            return View(topic);
        }

        public async Task< IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = await _topicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return View(topic);
            }
            _topicRepo.Update(topic);
            return RedirectToAction("Index");
        }

        public async Task< ActionResult?> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var topic = await _topicRepo.GetById(id.Value);
            if (topic == null)
            {
                return NotFound();
            }
            _topicRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
