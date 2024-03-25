using Examination.data;
using Examination.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Examination.Repos
{
    public interface IQuestionRepo
    {
       Task< List<Question>> GetAll();
        Task Add(Question question);
        public Question GetById(int id);
        void Delete(int id);
        void Update(Question question);

    }
    public class QuestionRepo:IQuestionRepo
    {
        public readonly ExamContext db;

        public QuestionRepo( ExamContext _db)
        {
            db = _db;
        }

        public async Task Add(Question question)
        {
            // throw new NotImplementedException();
            var parameters = new[]
            {      new SqlParameter("@Question_Body", question.QuestionBody),
                new SqlParameter("@Question_Type", question.QuestionType),
                new SqlParameter("@Question_Answer", question.QuestionAnswer),
                new SqlParameter("@Topic_ID", question.TopicId),
                new SqlParameter("@Password", question.CourseId), };

            await db.Database.ExecuteSqlRawAsync("exec InsertQuestion @Question_Body, @Question_Type, @Question_Answer, @Topic_ID, @Course_ID", parameters);

            await db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            db.Students.FromSql($"exec sp_DeleteStudent {id}");
        }

        public async Task<  List<Question>> GetAll()
        {
            return await  db.Questions.FromSqlRaw("exec GetQuestions").ToListAsync();
        }

        public Question GetById(int id)
        {

            return db.Questions.FromSql($"exec GetQuestionByID{id}").AsEnumerable().FirstOrDefault();
        }

        public void Update(Question question)
        {
            //throw new NotImplementedException();

            var parameters = new SqlParameter[]
      {
                new SqlParameter("@Question_ID", question.Id),
                new SqlParameter("@Question_Body", question.QuestionBody),
                new SqlParameter("@Question_Type", question.QuestionType),
                new SqlParameter("@Question_Answer", question.QuestionAnswer),
                new SqlParameter("@Topic_ID", question.TopicId),
                new SqlParameter("@Password", question.CourseId),
              
      };

            db.Questions.FromSqlRaw("EXEC UpdateQuestion @Question_ID, @Question_Body, @Question_Type, @Question_Answer, @Topic_ID, @Course_ID", parameters);
                
            db.SaveChanges();
        }
    }
}
