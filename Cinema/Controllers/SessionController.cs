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
    public class SessionController : Controller
    {
        //private CinemaContext db = new CinemaContext();
        private readonly GenericRepository<Session> repo;
        private readonly GenericRepository<Hall> hallRepo;
        private readonly GenericRepository<Movie> movieRepo;

        public SessionController()
        {
            repo = new GenericRepository<Session>(new CinemaContext());
            hallRepo = new GenericRepository<Hall>(new CinemaContext());
            movieRepo = new GenericRepository<Movie>(new CinemaContext());
        }

        // GET: Session
        public ActionResult Index()
        {
            //var sessions = db.Sessions.Include(s => s.Hall).Include(s => s.Movie);
            return View(repo.GetAll().Include(s => s.Hall).Include(s => s.Movie).ToList());
        }

        // GET: Session/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Session session = db.Sessions.Find(id);
            Session session = repo.GetById(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // GET: Session/Create
        public ActionResult Create()
        {
            //ViewBag.HallId = new SelectList(db.Halls, "Id", "Id");
            //ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName");
            ViewBag.HallId = new SelectList(hallRepo.GetAll(), "Id", "Id");
            ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "Id", "MovieName");
            return View();
        }

        // POST: Session/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDateTime,MovieId,HallId")] Session session)
        {
            if (ModelState.IsValid)
            {
                //db.Sessions.Add(session);
                //db.SaveChanges();
                repo.Insert(session);
                repo.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.HallId = new SelectList(db.Halls, "Id", "Id", session.HallId);
            //ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", session.MovieId);
            ViewBag.HallId = new SelectList(hallRepo.GetAll(), "Id", "Id", session.HallId);
            ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "Id", "MovieName", session.MovieId);
            return View(session);
        }

        // GET: Session/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Session session = db.Sessions.Find(id);
            Session session = repo.GetById(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            //ViewBag.HallId = new SelectList(db.Halls, "Id", "Id", session.HallId);
            //ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", session.MovieId);
            ViewBag.HallId = new SelectList(hallRepo.GetAll(), "Id", "Id", session.HallId);
            ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "Id", "MovieName", session.MovieId);
            return View(session);
        }

        // POST: Session/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDateTime,MovieId,HallId")] Session session)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(session).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(session);
                repo.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.HallId = new SelectList(db.Halls, "Id", "Id", session.HallId);
            //ViewBag.MovieId = new SelectList(db.Movies, "Id", "MovieName", session.MovieId);
            ViewBag.HallId = new SelectList(hallRepo.GetAll(), "Id", "Id", session.HallId);
            ViewBag.MovieId = new SelectList(movieRepo.GetAll(), "Id", "MovieName", session.MovieId);
            return View(session);
        }

        // GET: Session/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Session session = db.Sessions.Find(id);
            Session session = repo.GetById(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: Session/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Session session = db.Sessions.Find(id);
            //db.Sessions.Remove(session);
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
