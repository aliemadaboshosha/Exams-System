using Examination.data;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Examination.Repos
{

    public interface ITrackRepo
    {
        List<Track> GetAll();
        Track GetById(int id);
        void Add(Track br);
        void Delete(int id);
        void Update(Track br);
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
            {
                var Track = db.Tracks.FromSql($"exec SelectTrackByID {id}").AsEnumerable().FirstOrDefault();
                return Track;
            }
        }
        public List<Track> GetAll()
        {
            var trackes = db.Tracks.FromSql($"exec GetTracks").AsEnumerable().ToList();
            return trackes;
        }
        public async void Add(Track track)
        {
            var result = await db.Database.ExecuteSqlRawAsync(
                       $"exec insertTrack {track.Name}");
            //db.Tracks.Add( track ); : without stored procedure
            db.SaveChanges();
        }
        public async void Update(Track Track)
        {

          var result = await db.Database.ExecuteSqlRawAsync(
                        $"EXEC UpdateTrackByID {Track.Id} ,{Track.Name}");
            //db.Tracks.Update(Track);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
           db.Tracks.FromSql($"exec DeleteTrackByID {id}").AsEnumerable().FirstOrDefault(); ;
            //db.Tracks.Remove(GetById(id));
            db.SaveChanges();
        }

    }
}
