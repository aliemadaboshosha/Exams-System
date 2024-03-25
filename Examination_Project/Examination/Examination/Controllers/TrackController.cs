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

        public IActionResult Index()
        {
            var tracks = trackRepo.GetAll();
           
                return View(tracks);
        }
        public IActionResult Details(int? id)
        {
            var Track = trackRepo.GetById(id.Value);
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
        public IActionResult Update(int? id)
        {
            if (id == null)// if dees not enter id 
            {
                return BadRequest();
            }
            var Track = trackRepo.GetById(id.Value);
            if (Track == null)
            {
                return NotFound();
            }
            return View(Track);
        }

        [HttpPost]
        public  async Task<IActionResult> Update(Track br)
        {
            if (!ModelState.IsValid)// i dont use deptID as it identity in Db
            {
                return View(br);
            }
            trackRepo.Update(br);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Track = trackRepo.GetById(id.Value);
            if (Track == null)
            {
                return NotFound();
            }
            trackRepo.Delete(id.Value); // it will change the status only 
            return RedirectToAction("Index");
        }

    }
}
