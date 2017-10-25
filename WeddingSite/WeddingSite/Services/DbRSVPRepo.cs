using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingSite.Models.DbContexts;
using WeddingSite.Models.Entities;
using WeddingSite.Services.Interfaces;

namespace WeddingSite.Services
{
    public class DbRSVPRepo : IRSVPRepo
    {
        private RSVPDbContext _db;

        public DbRSVPRepo(RSVPDbContext db)
        {
            _db = db;
        }

        public ICollection<RSVP> ReadAll()
        {
            return _db.RSVPs.ToList();
        }

        public RSVP Create(RSVP rsvp)
        {
            _db.RSVPs.Add(rsvp);
            _db.SaveChanges();
            return rsvp;
        }

        public RSVP Read(int id)
        {
            return _db.RSVPs.FirstOrDefault(p => p.Id == id);
        }

        public void Update(int id, RSVP rsvp)
        {
            _db.Entry(rsvp).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            RSVP rsvp = _db.RSVPs.Find(id);
            _db.RSVPs.Remove(rsvp);
            _db.SaveChanges();

        }
    }
}
