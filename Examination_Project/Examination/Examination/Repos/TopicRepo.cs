using Examination.data;
using Examination.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Examination.Repos
{
    public interface ITopicRepo
    {
        List<Topic> GetAll();
        Topic GetById(int id);
        void Add(Topic topic);
        void Delete(int id);
        void Update(Topic topic);
    }

    public class TopicRepo : ITopicRepo
    {
        private readonly ExamContext _db;

        public TopicRepo(ExamContext db)
        {
            _db = db;
        }

        public Topic GetById(int id)
        {
            return _db.Topics.FromSqlInterpolated($"exec getTopicByID {id}").FirstOrDefault();
        }

        public List<Topic> GetAll()
        {
            return _db.Topics.FromSqlRaw("exec getTopics").AsEnumerable().ToList();
        }

        public void Add(Topic topic)
        {
            _db.Database.ExecuteSqlInterpolated(
                $"exec insertTopic {topic.Name}, {topic.CourseId}");
            _db.SaveChanges();
        }

        public void Update(Topic topic)
        {
            _db.Database.ExecuteSqlInterpolated(
                $"exec update_TopicByID {topic.Id}, {topic.Name}, {topic.CourseId}");
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Database.ExecuteSqlInterpolated($"exec DeleteTopicByID {id}");
            _db.SaveChanges();
        }

    }
}
