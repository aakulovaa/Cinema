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
    public class PeopleController : Controller
    {
        //private CinemaContext db = new CinemaContext();
        private readonly GenericRepository<People> repo;
        private readonly GenericRepository<TicketSold> TicketRepo;

        public PeopleController()
        {
            repo = new GenericRepository<People>(new CinemaContext());
            TicketRepo = new GenericRepository<TicketSold>(new CinemaContext());
        }

        // GET: People
        public ActionResult Index()
        {
            //var peoples = db.Peoples.Include(p => p.TicketSold);
            return View(repo.GetAll().Include(p => p.TicketSold).ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //People people = db.Peoples.Find(id);
            People people = repo.GetById(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            // ViewBag.Id = new SelectList(db.TicketSolds, "Id", "Id");
            ViewBag.Id = new SelectList(TicketRepo.GetAll(), "Id", "Id");
            return View();
        }

        // POST: People/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] People people)
        {
            if (ModelState.IsValid)
            {
                //db.Peoples.Add(people);
                //db.SaveChanges();
                //return RedirectToAction("Index");

                //people.TicketSold = peopleTicketSold;
                //repo.Insert(people);
                //TicketRepo.Insert(peopleTicketSold);
                //repo.Save();
                //TicketRepo.Save();
                repo.Insert(people);
                repo.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.Id = new SelectList(db.TicketSolds, "Id", "Id", people.Id);
            ViewBag.Id = new SelectList(TicketRepo.GetAll(), "Id", "Id", people.Id);
            return View(people);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //People people = db.Peoples.Find(id);
            People people = repo.GetById(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.TicketSolds, "Id", "Id", people.Id);
            ViewBag.Id = new SelectList(TicketRepo.GetAll(), "Id", "Id", people.Id);

            return View(people);
        }

        // POST: People/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] People people)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(people).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(people);
                repo.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.TicketSolds, "Id", "Id", people.Id);
            ViewBag.Id = new SelectList(TicketRepo.GetAll(), "Id", "Id", people.Id);
            return View(people);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //People people = db.Peoples.Find(id);
            People people = repo.GetById(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //People people = db.Peoples.Find(id);
            //db.Peoples.Remove(people);
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
