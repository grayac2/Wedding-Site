using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingSite.Models.Entities;

namespace WeddingSite.Services.Interfaces
{
    public interface IRSVPRepo
    {
        RSVP Create(RSVP rsvp);

        RSVP Read(int id);

        ICollection<RSVP> ReadAll();

        void Update(int id, RSVP rsvp);

        void Delete(int id);

    }
}
