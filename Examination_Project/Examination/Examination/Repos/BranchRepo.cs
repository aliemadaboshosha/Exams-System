using Examination.data;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Examination.Repos
{
    
    public interface IBranchRepo
    {
        List<Branch> GetAll();
        Branch GetById(int id);
        void Add(Branch br);
        void Delete(int id);
         void  Update(Branch br);
    }
    public class BranchRepo : IBranchRepo
    {
        public ExamContext db;
        public BranchRepo(ExamContext db)
        {
            this.db = db;
        }
        public Branch GetById(int id)
        {
            {
                var branch = db.Branches.FromSql($"exec getBranchByID {id}").AsEnumerable().FirstOrDefault();
                return branch;
            }
        }
        public List<Branch> GetAll ()
        {
            var branches =  db.Branches.FromSql($"exec getBranches").AsEnumerable().ToList(); 
            return branches;
        }
        public async void Add(Branch br)
        {
        
                //var result = await departmentRepository.Add(new Department() { dept_name = department.dept_name });
                var result = await db.Database.ExecuteSqlRawAsync(
                           $"exec insertBranch {br.Name},{br.BuildingNumber},{br.Street},{br.City}");


            // db.Branches.FromSql($"exec insertBranch {br.Name},{br.BuildingNumber},{br.Street},{br.City}");
            // db.Branches.Add(br);
            db.SaveChanges();
        }
        public  async void Update(Branch branch)
        {
           
            var result = await db.Database.ExecuteSqlRawAsync(
                          $"EXEC update_BranchByID  {branch.Id} , {branch.Name} , {branch.BuildingNumber},{branch.Street},{branch.City}") ;
            //db.Branches.Update(branch);
            db.SaveChanges();
        
        }
        public void Delete(int id)
        {
            db.Branches.FromSql($"exec DeleteBranchByID {id}").AsEnumerable().FirstOrDefault(); ;
          //db.Branches.Remove(GetById(id));
            db.SaveChanges();
        }


    }
}
