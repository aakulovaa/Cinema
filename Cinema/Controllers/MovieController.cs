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
    public class MovieController : Controller
    {
        //private CinemaContext db = new CinemaContext();
        private readonly GenericRepository<Movie> repo;
        public MovieController()
        {
            repo = new GenericRepository<Movie>(new CinemaContext());
        }

        // GET: Movie
        public ActionResult Index()
        {
            //return View(db.Movies.ToList());
            return View(repo.GetAll());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            Movie movie = repo.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieName,YearRelease,Director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Movies.Add(movie);
                //db.SaveChanges();
                repo.Insert(movie);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            Movie movie = repo.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieName,YearRelease,Director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(movie).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(movie);
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Movie movie = db.Movies.Find(id);
            Movie movie = repo.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Movie movie = db.Movies.Find(id);
            //db.Movies.Remove(movie);
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
