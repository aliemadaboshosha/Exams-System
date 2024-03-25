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
        Task<Topic> GetById(int id);
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

        public async  Task<Topic> GetById(int id)
        {
            var topics = await _db.Topics.FromSqlRaw($"exec getTopicByID {id}").ToListAsync();
            return topics.FirstOrDefault();
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
                $"exec UpdateTopic {topic.Id}, {topic.Name}, {topic.CourseId}");
            _db.SaveChanges();


          
        }

        public void Delete(int id)
        {
            _db.Database.ExecuteSqlInterpolated($"exec DeleteTopic {id}");
            _db.SaveChanges();


      
        }

    }
}
