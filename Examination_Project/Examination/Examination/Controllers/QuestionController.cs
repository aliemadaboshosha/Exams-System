using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examination.Models;
using Examination.data;
using Examination.Repos;

namespace Examination.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ExamContext _context;
        IQuestionRepo questionRepo;

        public QuestionController(ExamContext context,IQuestionRepo _questionRepo)
        {
            _context = context;
            questionRepo = _questionRepo;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            //    var examContext = _context.Questions.Include(q => q.Topic);
            var questions = await questionRepo.GetAll();
            return View(questions);
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            HashSet<Course> courses = _context.Courses.ToHashSet<Course>();
          
            ViewData["CourseId"] = new SelectList(courses, "Id", "Name");
            HashSet<Topic> topicList=_context.Topics.ToHashSet<Topic>();
            ViewData["TopicId"] = new SelectList(topicList, "Id", "Name");
            return View();
        }

        public IActionResult GetTopicsByCourse(int courseId)
        {
            // Retrieve topics associated with the selected course
            var topics = _context.Topics.Where(t => t.CourseId == courseId).Select(t => new { Id = t.Id, Name = t.Name }).ToList();
            return Json(topics);
        }

        // POST: Question/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionBody,QuestionType,QuestionAnswer,TopicId,CourseId")] Question question,string? MultiChoice1, string? MultiChoice2,string? MultiChoice3,string?  MultiChoice4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                question.MultiChoicesQuestionAnswers.Add(new MultiChoicesQuestionAnswer() { QuestionId = question.Id, NumberOfChoice = 1, BodyOfChoice = MultiChoice1 });
                question.MultiChoicesQuestionAnswers.Add(new MultiChoicesQuestionAnswer() { QuestionId = question.Id, NumberOfChoice = 2, BodyOfChoice = MultiChoice2 });
                question.MultiChoicesQuestionAnswers.Add(new MultiChoicesQuestionAnswer() { QuestionId = question.Id, NumberOfChoice = 3, BodyOfChoice = MultiChoice3 });
                question.MultiChoicesQuestionAnswers.Add(new MultiChoicesQuestionAnswer() { QuestionId = question.Id, NumberOfChoice = 4, BodyOfChoice = MultiChoice4 });
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "Id", question.TopicId);
            HashSet<Course> courses = _context.Courses.ToHashSet<Course>();
            
            ViewData["CourseId"] = new SelectList(courses, "Id", "Name");
            HashSet<Topic> topicList = _context.Topics.ToHashSet<Topic>();
            ViewData["TopicId"] = new SelectList(topicList, "Id", "Name");
            return View(question);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            HashSet<Course> courses = _context.Courses.ToHashSet<Course>();

            ViewData["CourseId"] = new SelectList(courses, "Id", "Name",question.CourseId);
            HashSet<Topic> topicList = _context.Topics.ToHashSet<Topic>();
            ViewData["TopicId"] = new SelectList(topicList, "Id", "Name", question.TopicId);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionBody,QuestionType,QuestionAnswer,TopicId,CourseId")] Question question, string? MultiChoice1, string? MultiChoice2, string? MultiChoice3, string? MultiChoice4)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   var questionInDataBase= _context.Questions.FirstOrDefault(q=>q.Id==id);
                    if (questionInDataBase == null) { return NotFound(); }
                    else 
                    {
                        questionInDataBase.QuestionBody = question.QuestionBody;
                        questionInDataBase.QuestionAnswer = question.QuestionAnswer;
                        if (questionInDataBase.QuestionType)
                        {
                            questionInDataBase.MultiChoicesQuestionAnswers.ElementAt(0).BodyOfChoice = MultiChoice1;
                            questionInDataBase.MultiChoicesQuestionAnswers.ElementAt(1).BodyOfChoice = MultiChoice2;
                            questionInDataBase.MultiChoicesQuestionAnswers.ElementAt(2).BodyOfChoice = MultiChoice3;
                            questionInDataBase.MultiChoicesQuestionAnswers.ElementAt(3).BodyOfChoice = MultiChoice4;
                        }

                        await _context.SaveChangesAsync();

                    }


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            HashSet<Course> courses = _context.Courses.ToHashSet<Course>();

            ViewData["CourseId"] = new SelectList(courses, "Id", "Name", question.CourseId);
            HashSet<Topic> topicList = _context.Topics.ToHashSet<Topic>();
            ViewData["TopicId"] = new SelectList(topicList, "Id", "Name", question.TopicId);
            return View(question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
