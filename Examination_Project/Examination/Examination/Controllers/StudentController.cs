using Examination.data;
using Examination.Models;
using Examination.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination.Controllers
{
    public class StudentController : Controller
    {
       IstudentRepo studentRepo;
        IBranchRepo branchRepo;
        ITrackRepo trackRepo;
        public StudentController(IstudentRepo studentRepo ,IBranchRepo branchRepo , ITrackRepo trackRepo) { 
            this.studentRepo = studentRepo; 
            this.branchRepo = branchRepo;
            this.trackRepo = trackRepo;
        }
        public IActionResult Index()
        {
            var students = studentRepo.GetAll();

            return View(students);
        }

        public async Task <IActionResult> Details(int ? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student =  studentRepo.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Branch> branches = new List<Branch>();
            branches = await branchRepo.GetAll() ?? new List<Branch>();
            List<Track> tracks = await trackRepo.GetAll() ?? new List<Track>();
            ViewBag.Branches = branches;
            Console.WriteLine(ViewBag.Branches.Count);
            ViewBag.Tracks = tracks;
            Console.WriteLine(ViewBag.Tracks.Count);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await studentRepo.Add(student); // Assuming AddAsync is asynchronous

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            List<Branch> branches = new List<Branch>();
            branches = await branchRepo.GetAll() ?? new List<Branch>();
            List<Track> tracks = await trackRepo.GetAll() ?? new List<Track>();
            ViewBag.Branches = branches;
            ViewBag.Tracks = tracks;
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int ? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = studentRepo.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            List<Branch> branches = new List<Branch>();
            branches = await branchRepo.GetAll() ?? [];
            ViewBag.Branches = branches;
            List<Track> tracks = await trackRepo.GetAll() ?? [];
            ViewBag.Tracks = tracks;
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                List<Branch> branches = new List<Branch>();
                branches = await branchRepo.GetAll() ?? [];
                List<Track> tracks = await trackRepo.GetAll() ?? [];
                ViewBag.Branches = branches;
                ViewBag.Tracks = tracks;
                return View(student);
            }
            await studentRepo.Update(student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = studentRepo.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            await studentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}
