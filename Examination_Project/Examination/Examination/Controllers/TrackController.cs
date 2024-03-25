using Examination.Models;
using Examination.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Controllers
{
    public class TrackController : Controller
    {
        public ITrackRepo trackRepo;
        public TrackController(ITrackRepo trackRepo) { 
            this .trackRepo = trackRepo;
        }

        public async Task<IActionResult> Index()
        {
            var tracks = await trackRepo.GetAll();
            return View(tracks);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var Track =  trackRepo.GetById(id.Value);
            if (Track == null)
            {
                return NotFound();
            }
            return View(Track);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Track Track)
        {
            if (ModelState.IsValid)
            {
                trackRepo.Add(Track);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "invalid data ");
            return View(Track);

        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var track =  trackRepo.GetById(id.Value);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Track track)
        {
            if (!ModelState.IsValid)
            {
                return View(track);
            }
            await trackRepo.Update(track);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var track =  trackRepo.GetById(id.Value);
            if (track == null)
            {
                return NotFound();
            }
            await trackRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }


    }
}
