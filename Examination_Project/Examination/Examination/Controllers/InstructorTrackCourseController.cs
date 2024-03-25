using Examination.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination.Controllers
{
    public class InstructorTrackCourseController : Controller
    {
        ExamContext db;
        public InstructorTrackCourseController(ExamContext _examContext)
        {
            db = _examContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        // Track ID 

        public IActionResult ShowCoursesInTrackByID(int trackID)
        {
            // get all rows for track with id 
            var trackCourses =db.InstructorTrackCourses.Where(t =>t.TrackId == trackID).ToList(); 
            if(trackCourses == null || trackCourses.Count==0)
            {
                return Content ("There is no courses in this Track");
            }
            return View(trackCourses);
            
        }

        public IActionResult AddCoursesInTrackByID(int trackID)
        {
            if (trackID == null)
            {
                return BadRequest();
            }
            var track = db.Tracks.FirstOrDefault(a => a.Id == trackID);
            if (track == null)
            {
                return NotFound();
            }
            // i want user to select only the tracks that are not already found in TrackBranches Tabel
            var allcourses = db.Courses.ToList(); // all courses 
            // get already  Courses assigned to  the selected Track
            var trackcourses = db.InstructorTrackCourses.Where(a => a.TrackId == trackID).Select(a => a.Course);
            var availableCoures = allcourses.Except(trackcourses).ToList();
            ViewBag.Courses = availableCoures;
            // in the track the instructor can teach many courses , so i can select the same instructor again with another courses 
            ViewBag.instructors = db.Instructors.ToList();// all instructors
            return View(track);
        }

        [HttpPost]
        public IActionResult AddCoursesInTrackByID(int trackId, int crsId, int instructorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var trackCourses = db.InstructorTrackCourses.SingleOrDefault(a => a.TrackId == trackId && a.CourseId == crsId && a.InstructorId == instructorId);

            if (trackCourses == null)// if there is no row with the same data 
            {
                db.InstructorTrackCourses.Add
                    (new Models.InstructorTrackCourse {InstructorId = instructorId ,TrackId = trackId, CourseId = crsId });
                db.SaveChanges();
                return RedirectToAction("Index", "Track");
            }

            else// if there is in the same InstructorTrackCourses object in the table
            {
                ModelState.AddModelError(string.Empty, "This instructor and Course are already associated with the selected Track.");
                var track = db.Tracks.FirstOrDefault(a => a.Id == trackId);
                var allcourses = db.Courses.ToList();                                 
                var trackcourses = db.InstructorTrackCourses.Where(a => a.TrackId == trackId).Select(a => a.Course);
                var availableCoures = allcourses.Except(trackcourses).ToList();
                ViewBag.Courses = availableCoures;
                ViewBag.instructors = db.Instructors.ToList();// all instructors
                return View(track);
            }
        }

       
        public IActionResult ShowStudentsInTrackByID(int trackId)
        {
           // var track =db.Tracks.Where(a=>a.Id ==trackId).FirstOrDefault();
            var students = db.Students.FromSqlRaw($"GetStudentsByTrackID {trackId}").AsEnumerable().ToList();
            if(students == null || students.Count == 0)
                return Content("there are no students in this track");
            return View(students);
        }

    }
}
