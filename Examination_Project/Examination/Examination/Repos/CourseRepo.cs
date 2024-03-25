using Examination.data;
using Examination.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Examination.Repos
{
    public interface ICourseRepo
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Add(Course Crs);
        void Delete(int id);
        void Update(Course Crs);
    }

    public class CourseRepo : ICourseRepo
    {
        private readonly ExamContext _db;

        public CourseRepo(ExamContext db)
        {
            _db = db;
        }

        public Course GetById(int id)
        {
            var course = _db.Courses.FromSql($"exec GetCourseById {id}").AsEnumerable().FirstOrDefault();
            return course;
        }

        public List<Course> GetAll()
        {
            return _db.Courses.FromSqlRaw("exec getCourses").AsEnumerable().ToList();
        }

        public void Add(Course Course)
        {
            _db.Database.ExecuteSqlInterpolated(
                $"exec insertCourse {Course.Name}");
            _db.SaveChanges();
        }

        public void Update(Course Course)
        {
            _db.Database.ExecuteSqlInterpolated(
                $"exec UpdateCourse {Course.Id}, {Course.Name}");
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
           // _db.Database.ExecuteSqlInterpolated($"exec DeleteCourseByID {id}");
         
            _db.Database.ExecuteSqlInterpolated(
             $"exec DeleteCourseByID {id}");
            _db.SaveChanges();
        }

    }
}
