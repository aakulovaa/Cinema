using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class HallController : Controller
    {
        private readonly GenericRepository<Hall> repo;
        public HallController()
        {
            repo = new GenericRepository<Hall>(new CinemaContext());
        }
        //private CinemaContext db = new CinemaContext();

        // GET: Hall
        public ActionResult Index()
        {
            // return View(db.Halls.ToList());
            return View(repo.GetAll());
        }

        // GET: Hall/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Hall hall = db.Halls.Find(id);
            Hall hall = repo.GetById(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Hall/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hall/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,ScreenSize,HallSize")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                //db.Halls.Add(hall);
                //db.SaveChanges();
                repo.Insert(hall);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(hall);
        }

        // GET: Hall/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Hall hall = db.Halls.Find(id);
            Hall hall = repo.GetById(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Hall/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,ScreenSize,HallSize")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(hall).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(hall);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(hall);
        }

        // GET: Hall/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Hall hall = db.Halls.Find(id);
            Hall hall = repo.GetById(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Hall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Hall hall = db.Halls.Find(id);
            //db.Halls.Remove(hall);
            //db.SaveChanges();
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
