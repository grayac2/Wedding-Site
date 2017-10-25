using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingSite.Models.Entities;

namespace WeddingSite.Models.DbContexts
{
    public class RSVPDbContext : DbContext
    {
        public RSVPDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RSVP> RSVPs { get; set; }
    }
}
