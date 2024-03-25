using Examination.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination.Controllers
{
    public class BranchTracksController : Controller
    {
        ExamContext db;
        public BranchTracksController(ExamContext _examContext) {
            db = _examContext;
        }

        public IActionResult ShowBranchTracksByID( int id)
        {
            var branchTracks = db.TrackBranches.Include(a=>a.Branch).Include(a=>a.Track).Include(a=>a.Supervisor)
                .FirstOrDefault(a=>a.BranchId == id);
                ViewBag.branch = branchTracks.Branch;
                ViewBag.track = branchTracks.Track;
                ViewBag.supervisor = branchTracks.Supervisor;
            return View(branchTracks);
        }

        public IActionResult AddBranchTracks(int ?branchID)
        {
            if (branchID == null)
            {
                return BadRequest();    
            }
            var branch = db.Branches.Include(b => b.Instructors).FirstOrDefault(a=> a.Id == branchID);  
            if (branch == null)
            {
                return NotFound();
            }
            ViewBag.courses = db.Courses.ToList();
            ViewBag.tracks = db.Tracks.ToList();
            ViewBag.instructors = db.Instructors.ToList();  
            return View(branch);    
        }


    }
}
