using Examination.data;
using Examination.Models;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.DependencyResolver;
using System.Data;
using System.IO;

namespace Examination.Repos
{
    public interface IstudentRepo
    {
        List<Student> GetAll();
        Task Add(Student student);
        public Student GetById(int id);
        void Delete(int id);
        void Update(Student student);

    }
    public class StudentRepo: IstudentRepo
    {
         public readonly ExamContext db;

        public StudentRepo(ExamContext db)
        {
            this.db = db;
        }

        public List<Student> GetAll()
        {
            //to include the Department every time we read Student from the database
            //return db.Students.Include(s => s.Department).ToList();
            var students = db.Students.FromSql($"exec sp_GetStudents").ToList();
            return students;
        }
        #region Old version of add student
        //public async Task Add(Student student)
        //{
        //    var students = await db.Students
        //        .FromSqlRaw("EXEC sp_CreateStudent @FirstName, @LastName, @Gender, @Email, @Password, @Street, @City, @DateOfBirth, @BranchID, @TrackID,",
        //            new SqlParameter("@FirstName", student.Fname),
        //            new SqlParameter("@LastName", student.Lname),
        //            new SqlParameter("@Gender", student.Gender),
        //            new SqlParameter("@Email", student.Email),
        //            new SqlParameter("@Password", student.Password),
        //            new SqlParameter("@Street", student.Street),
        //            new SqlParameter("@City", student.City),
        //            new SqlParameter("@DateOfBirth", student.DateOfBirth),
        //            new SqlParameter("@BranchID", student.BranchId),
        //            new SqlParameter("@TrackID", student.TrackId))
        //        .ToListAsync();

        //    // Assuming students is a list of newly added students, but you might not need it

        //    await db.SaveChangesAsync();
        //}

        #endregion

        #region new version
        public async Task Add(Student student)
        {
            // Create parameters for the stored procedure
            var parameters = new[]
            {
        new SqlParameter("@FirstName", student.Fname),
        new SqlParameter("@LastName", student.Lname),
        new SqlParameter("@Gender", student.Gender),
        new SqlParameter("@Email", student.Email),
        new SqlParameter("@Password", student.Password),
        new SqlParameter("@Street", student.Street),
        new SqlParameter("@City", student.City),
        new SqlParameter("@DateOfBirth", student.DateOfBirth),
        new SqlParameter("@BranchID", student.BranchId),
        new SqlParameter("@TrackID", student.TrackId),
        new SqlParameter("@InsertedId", SqlDbType.Int) { Direction = ParameterDirection.Output } // Output parameter to get the inserted ID
    };

            // Execute the stored procedure
            await db.Database.ExecuteSqlRawAsync("EXEC sp_CreateStudent @FirstName, @LastName, @Gender, @Email, @Password, @Street, @City, @DateOfBirth, @BranchID, @TrackID, @InsertedId OUTPUT", parameters);

            // Get the ID of the inserted student from the output parameter
            var insertedId = (int)parameters[parameters.Length - 1].Value;

            // You might perform additional operations with the insertedId if needed

            // Save changes to the database
            await db.SaveChangesAsync();
        }

        #endregion
        public Student GetById(int id)
        {
            var student = db.Students.FromSql($"exec sp_GetStudentById {id}").AsEnumerable().FirstOrDefault();
            return student;
        }

        public void Update(Student student)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", student.ID),
                new SqlParameter("@FirstName", student.Fname),
                new SqlParameter("@LastName", student.Lname),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@Password", student.Password),
                new SqlParameter("@Street", student.Street),
                new SqlParameter("@City", student.City),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@BranchID", student.BranchId),
                new SqlParameter("@TrackID", student.TrackId)
            };

            db.Students.FromSqlRaw("EXEC sp_UpdateStudent @Id, @FirstName, @LastName, @Gender, @Email, @Password, @Street, @City, @DateOfBirth, @BranchID, @TrackID", parameters)
                .FirstOrDefault();
            db.SaveChanges();
        }
        //FromSql : does not have more than 2 parameters ,
        // so uing FromSqlRaw

        public void Delete(int id)
        {
            db.Students.FromSql($"exec sp_DeleteStudent {id}").FirstOrDefault();
            db.SaveChanges();
        }
    }


}

