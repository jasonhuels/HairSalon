using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Client> model = _db.Clients.Include(clients => clients.Stylist).ToList();

            return View(model);

        }

        public ActionResult Create()
        {
            ViewBag.StylistID = new SelectList(_db.Stylists, "StylistID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            List<Client> model = _db.Clients.Include(clients => clients.Stylist).ToList();
            Client client = _db.Clients.FirstOrDefault(clients => clients.ClientID == id);
            return View(client);
        }

        public ActionResult Edit(int id)
        {
            var client = _db.Clients.FirstOrDefault(clients => clients.ClientID == id);
            ViewBag.StylistId = new SelectList(_db.Stylists, "StylistID", "Name");
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Client client = _db.Clients.FirstOrDefault(clients => clients.ClientID == id);
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = _db.Clients.FirstOrDefault(clients => clients.ClientID == id);
            _db.Clients.Remove(client);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}