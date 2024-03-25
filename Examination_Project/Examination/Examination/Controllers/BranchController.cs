using Examination.Repos;
using Microsoft.AspNetCore.Mvc;
using Examination.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examination.Controllers
{
    public class BranchController : Controller
    { 

        public IBranchRepo branchRepo;
        public BranchController(IBranchRepo branchRepo) {
        this.branchRepo = branchRepo;
        }
        public IActionResult Index()
        {
            var branches = branchRepo.GetAll();
            return View(branches);
        }
        public IActionResult Details(int? id)
        {
            var branch = branchRepo.GetById(id.Value);
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
          if(ModelState.IsValid)
            {
                branchRepo.Add(branch);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("","invalid data ");
            return View(branch);

        }   
        public IActionResult Update(int ?id ) {
            if (id == null)// if dees not enter id 
            {
                return BadRequest();
            }
            var branch = branchRepo.GetById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Branch br)
        {
            if (!ModelState.IsValid)// i dont use deptID as it identity in Db
            {
                return View(br);
            }
            branchRepo.Update(br);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var branch = branchRepo.GetById(id.Value);
            if (branch == null)
            {
                return NotFound();
            }
            branchRepo.Delete(id.Value); // it will change the status only 
            return RedirectToAction("Index");
        }


    }
}
