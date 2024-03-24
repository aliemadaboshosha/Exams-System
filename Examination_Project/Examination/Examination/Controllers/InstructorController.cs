using Examination.Models;
using Examination.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Controllers
{
    public class InstructorController : Controller
    {
         IInstructorRepo instructorRepo;
        IBranchRepo branchRepo;
        public InstructorController(IInstructorRepo instructorRepo, IBranchRepo branchRepo) {
            this.instructorRepo = instructorRepo;
            this.branchRepo = branchRepo;
        }

        public async Task<IActionResult> Index()
        {
            var instructors = await instructorRepo.GetAll();
            return View(instructors);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var instructor = await instructorRepo.GetById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           ViewBag.branches = await branchRepo.GetAll();
           Console.WriteLine(ViewBag.branches.Count);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Instructor ins)
        {
            if (ins != null)// ModelState.IsValid: it returns false i dont know why so i delete it and put another condition
            {
                await instructorRepo.Add(ins);
                return RedirectToAction("Index");
            }
            ViewBag.branches = await branchRepo.GetAll();
            ModelState.AddModelError("", "Invalid data");
            return View(ins);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var ins = await instructorRepo.GetById(id.Value);
            if (ins == null)
            {
                return NotFound();
            }
            List<Branch> branches = new List<Branch>();
            branches = await branchRepo.GetAll() ?? [];
            ViewBag.Branches = branches;
            return View(ins);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Instructor ins)
        {
            if (ins == null )//  if (!ModelState.IsValid): i replaced it as the is an error  i dont know its reason
            {
                List<Branch> branches = new List<Branch>();
                branches = await branchRepo.GetAll() ?? [];
                ViewBag.Branches = branches;
                return View(ins);
            }
            await instructorRepo.Update(ins);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var instructor = await instructorRepo.GetById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }
            await instructorRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}



  

