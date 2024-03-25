using Examination.Models;
using Examination.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examination.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepo branchRepo;

        public BranchController(IBranchRepo branchRepo)
        {
            this.branchRepo = branchRepo;
        }
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> Index()
        {
            var branches = await branchRepo.GetAll();
            return View(branches);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var branch = await branchRepo.GetById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                await branchRepo.Add(branch);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Invalid data");
            return View(branch);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var branch = await branchRepo.GetById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return View(branch);
            }

            await branchRepo.Update(branch);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var branch = await branchRepo.GetById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            await branchRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
