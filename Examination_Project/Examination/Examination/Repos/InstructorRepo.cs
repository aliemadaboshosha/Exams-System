using Examination.data;
using Examination.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Examination.Repos
{
    public interface IInstructorRepo
    {
        Task <List<Instructor>> GetAll();
        Task <Instructor> GetById(int id);
        Task Add(Instructor instructor);
        Task Delete(int id);
        Task Update(Instructor ins);
    }
    public class InstructorRepo : IInstructorRepo
    {
       
        ExamContext db;
        public InstructorRepo(ExamContext db) { 
            this.db = db;   
        }

        public async Task <List <Instructor>> GetAll()
        {
            return await db.Instructors.FromSqlRaw("exec GetIstructors").ToListAsync();
        }

        public async Task<Instructor> GetById(int id)
        {
            var instructor = await db.Instructors.FromSqlRaw($"exec sp_GetInstructorById {id}").ToListAsync();
            return instructor.FirstOrDefault();
        }
        // add Instructor 
        //public async Task Add(Instructor ins)
        //{
        //    await db.Database.ExecuteSqlRawAsync($"exec sp_CreateInstructor {ins.Fname} ,{ins.Lname},{ins.Gender},{ins.Email}," +
        //        $"{ins.Password},{ins.Street},{ins.City},{ins.DateOfBirth},{ins.Salary},{ins.BranchId}");
        //    await db.SaveChangesAsync();
        //}

        // or :add Instructor  
        public async Task Add(Instructor ins)
        {
            await db.Database.ExecuteSqlRawAsync(
                "EXEC sp_CreateInstructor @FirstName, @LastName, @Gender, @Email, @Password, " +
                "@Street, @City, @DateOfBirth, @Salary, @BranchID",
                new SqlParameter("@FirstName", ins.Fname),
                new SqlParameter("@LastName", ins.Lname),
                new SqlParameter("@Gender", ins.Gender),
                new SqlParameter("@Email", ins.Email),
                new SqlParameter("@Password", ins.Password),
                new SqlParameter("@Street", ins.Street),
                new SqlParameter("@City", ins.City),
                new SqlParameter("@DateOfBirth", ins.DateOfBirth),
                new SqlParameter("@Salary", ins.Salary),
                new SqlParameter("@BranchID", ins.BranchId)
            );
        }

            public async Task Update(Instructor ins)
        {
            await db.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateInstructor @ID ,@FirstName, @LastName, @Gender, @Email, @Password, " +
                "@Street, @City, @DateOfBirth, @Salary, @BranchID",
                new SqlParameter("@ID", ins.Id),
                new SqlParameter("@FirstName", ins.Fname),
                new SqlParameter("@LastName", ins.Lname),
                new SqlParameter("@Gender", ins.Gender),
                new SqlParameter("@Email", ins.Email),
                new SqlParameter("@Password", ins.Password),
                new SqlParameter("@Street", ins.Street),
                new SqlParameter("@City", ins.City),
                new SqlParameter("@DateOfBirth", ins.DateOfBirth),
                new SqlParameter("@Salary", ins.Salary),
                new SqlParameter("@BranchID", ins.BranchId)
            );

            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await db.Database.ExecuteSqlRawAsync($"exec sp_DeleteInstructor {id}");
            await db.SaveChangesAsync();
        }












    }
}
