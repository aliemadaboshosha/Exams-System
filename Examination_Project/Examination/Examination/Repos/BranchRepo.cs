using Examination.data;
using Examination.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination.Repos
{
    public interface IBranchRepo
    {
        Task<List<Branch>> GetAll();
        Task<Branch> GetById(int id);
        Task Add(Branch br);
        Task Delete(int id);
        Task Update(Branch br);
    }
    public class BranchRepo : IBranchRepo
    {
        private readonly ExamContext db;

        public BranchRepo(ExamContext db)
        {
            this.db = db;
        }

        public async Task<List<Branch>> GetAll()
        {
            return await db.Branches.FromSqlRaw("exec getBranches").ToListAsync();
        }

            public async Task<Branch> GetById(int id)
            {
                var branches = await db.Branches.FromSqlRaw($"exec getBranchByID {id}").ToListAsync();
                return branches.FirstOrDefault();
            }

        public async Task Add(Branch br)
        {
            await db.Database.ExecuteSqlRawAsync(
                "exec insertBranch @Name, @BuildingNumber, @Street, @City",
                new SqlParameter("@Name", br.Name),
                new SqlParameter("@BuildingNumber", br.BuildingNumber),
                new SqlParameter("@Street", br.Street),
                new SqlParameter("@City", br.City)
            );
            await db.SaveChangesAsync();
        }

        public async Task Update(Branch branch)
        {
            await db.Database.ExecuteSqlRawAsync(
                "EXEC update_BranchByID @Id, @Name, @BuildingNumber, @Street, @City",
                new SqlParameter("@Id", branch.Id),
                new SqlParameter("@Name", branch.Name),
                new SqlParameter("@BuildingNumber", branch.BuildingNumber),
                new SqlParameter("@Street", branch.Street),
                new SqlParameter("@City", branch.City)
            );
            await db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await db.Database.ExecuteSqlRawAsync($"exec DeleteBranchByID {id}");
            await db.SaveChangesAsync();
        }
    }
}
