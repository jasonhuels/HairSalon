using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;


namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        private readonly HairSalonContext _db;

        public StylistController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Stylist> model = _db.Stylists.OrderBy(s => s.Name).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stylist stylist)
        {
            _db.Stylists.Add(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            List<Client> model = _db.Clients.Include(clients => clients.Stylist).ToList();
            Stylist stylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistID == id);
            return View(stylist);
        }
        public ActionResult Edit(int id)
        {
            var stylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistID == id);
            return View(stylist);
        }

        [HttpPost]
        public ActionResult Edit(Stylist stylist)
        {
            _db.Entry(stylist).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var stylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistID == id);
            return View(stylist);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var stylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistID == id);

            foreach(Client client in _db.Clients)
            {
                Client thisClient = _db.Clients.FirstOrDefault(clients => clients.StylistID == id);
                if(thisClient != null)
                {
                    _db.Clients.Remove(thisClient);
                }
            }
            _db.Stylists.Remove(stylist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}