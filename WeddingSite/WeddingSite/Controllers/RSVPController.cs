using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingSite.Models;
using WeddingSite.Models.Entities;
using WeddingSite.Services.Interfaces;

namespace WeddingSite.Controllers
{
    public class RSVPController : Controller
    {
        private IRSVPRepo _rsvps;

        public RSVPController(IRSVPRepo rsvps)
        {
            _rsvps = rsvps;
        }


        public IActionResult Control()
        {
            return View(_rsvps.ReadAll());
        }

        public IActionResult Guestlist()
        {
            return View(_rsvps.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RSVP rsvp)
        {
            if (ModelState.IsValid)
            {
                _rsvps.Create(rsvp);
                return RedirectToAction("Details","RSVP", new { id = rsvp.Id });
            }
            return View();
        }

        public IActionResult Access()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Access(AccessVM accessvm)
        {
            int id = Int32.Parse(accessvm.strId);
            return RedirectToAction("Edit", "RSVP", new { id = id });
        }

        public IActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Admin(AdminVM adminvm)
        {
            if (adminvm.password == "password")
            {
                return RedirectToAction("Control", "RSVP");
            }
            else
            {
                return RedirectToAction("Admin", "RSVP");
            }
        }

        public IActionResult Edit(int id)
        {
            var rsvp = _rsvps.Read(id);
            if (rsvp == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(rsvp);
        }

        [HttpPost]
        public IActionResult Edit(RSVP rsvp)
        {
            if (ModelState.IsValid)
            {
                _rsvps.Update(rsvp.Id, rsvp);
                return RedirectToAction("Index","Home");
            }
            return View(rsvp);
        }

        public IActionResult Details(int id)
        {
            var rsvp = _rsvps.Read(id);
            if (rsvp == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(rsvp);
        }

        public IActionResult Delete(int id)
        {
            var rsvp = _rsvps.Read(id);
            if (rsvp == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(rsvp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            _rsvps.Delete(Id);
            return RedirectToAction("Index","Home");
        }

    }
}