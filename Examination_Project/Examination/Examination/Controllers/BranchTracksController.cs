using Examination.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Examination.Controllers
{
    public class BranchTracksController : Controller
    {
        ExamContext db;
        public BranchTracksController(ExamContext _examContext) {
            db = _examContext;
        }

        //public IActionResult ShowBranchTracksByID( int id)
        //{
        //    var branchTracks = db.TrackBranches.Include(a=>a.Branch).Include(a=>a.Track).Include(a=>a.Supervisor)
        //        .FirstOrDefault(a=>a.BranchId == id);
        //        ViewBag.branch = branchTracks.Branch;
        //        ViewBag.track = branchTracks.Track;
        //        ViewBag.supervisor = branchTracks.Supervisor;
        //    return View(branchTracks);
        //}
     

        public IActionResult ShowBranchTracksByID(int id)
        {
            var branchTracks = db.TrackBranches
                .Where(a => a.BranchId == id)
                .Include(a => a.Branch)
                .Include(a => a.Track)
                .Include(a => a.Supervisor)
                .ToList();

            if (branchTracks == null || branchTracks.Count == 0)
            {
                return Content($"there is no tracks in Branch With id {id}");
            }
            // this view will be accessed throw Branch id
            return View(branchTracks);
        }

        [HttpGet]
        public IActionResult AddBranchTracks(int ? branchId)
        {
            if (branchId == null)
            {
                return BadRequest();    
            }
            var branch = db.Branches.Include(b => b.Instructors).FirstOrDefault(a=> a.Id == branchId);  
            if (branch == null)
            {
                return NotFound();
            }
            // i want user to select only the tracks that are not already found in TrackBranches Tabel

            var allTracks = db.Tracks.ToList(); // all tracks 
            var branchTracks = db.TrackBranches.Where(a => a.BranchId == branchId).Select(a => a.Track);
            var availableTracks = allTracks.Except(branchTracks).ToList();
            ViewBag.Tracks = availableTracks;
            ViewBag.instructors = db.Instructors.ToList();  
            return View(branch);    
        }
        [HttpPost]
        public IActionResult AddBranchTracks(int branchId,int trackId ,int instructorId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var branchtrack = db.TrackBranches.SingleOrDefault(a=>a.BranchId == branchId && a.TrackId == trackId &&a.SupervisorId==instructorId);
            if (branchtrack == null)// if there is no row with the same data 
            {
                db.TrackBranches.Add
                    (new Models.TrackBranch { BranchId = branchId, TrackId = trackId, SupervisorId = instructorId });
                db.SaveChanges();
                return RedirectToAction("ShowBranchTracksByID", "BranchTracks", new { id = branchId });
            }
            else// if there is in the same TrackBranch object in the table
            {
                ModelState.AddModelError(string.Empty, "This supervisor and track are already associated with the selected branch.");
                var branch = db.Branches.Include(b => b.Instructors).FirstOrDefault(a => a.Id == branchId);
                var allTracks = db.Tracks.ToList(); // all tracks 
                var branchTracks = db.TrackBranches.Where(a => a.BranchId == branchId).Select(a => a.Track);
                var availableTracks = allTracks.Except(branchTracks).ToList();
                ViewBag.Tracks = availableTracks;
                ViewBag.instructors = db.Instructors.ToList();
                return View(branch);

            }

        }

    }
}
