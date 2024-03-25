using Examination.data;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Examination.Repos
{

    public interface ITrackRepo
    {
        Task<List<Track>> GetAll();
        Track GetById(int id);
        Task Add(Track track);
        Task Delete(int id);
        Task Update(Track track);
    }
    public class TrackRepo : ITrackRepo
    {
        public ExamContext db;
        public TrackRepo(ExamContext db)
        {
            this.db = db;
        }

        public Track GetById(int id)
        {
           
            //    var track = await db.Tracks.FromSqlRaw($"SELECT * FROM Track WHERE Id = {id}").FirstOrDefaultAsync();
            //return track;


            return  db.Tracks.FromSql($"exec SelectTrackByID {id}").AsEnumerable().FirstOrDefault();
            //db.Tracks.FirstOrDefault(a=>a.Id == id);// without stored procedure
        }

        public async Task<List<Track>> GetAll()
        {
            return await db.Tracks.FromSqlRaw("exec GetTracks").ToListAsync();
          
        }
        public async Task Add(Track track)
        {
            await db.Database.ExecuteSqlRawAsync(
                "EXEC InsertTrack @name",
                new SqlParameter("@name", track.Name)
            );
            await db.SaveChangesAsync();
        }

        public async Task Update(Track track)
        {
            await db.Database.ExecuteSqlRawAsync(
                "EXEC UpdateTrackByID @Id, @Name",
                new SqlParameter("@Id", track.Id),
                new SqlParameter("@Name", track.Name)
            );
            await db.SaveChangesAsync();
            //var result = await db.Database.ExecuteSqlRawAsync(
            //             $"EXEC UpdateTrackByID {Track.Id} ,{Track.Name}");
            // db.Tracks.Update(Track); //// without stored procedure
        }

        public async Task Delete(int id)
        {
            await db.Database.ExecuteSqlRawAsync($"exec DeleteTrackByID {id}");
            await db.SaveChangesAsync();

            //db.Tracks.Remove(GetById(id));// without stored procedure
        }

    }
}
