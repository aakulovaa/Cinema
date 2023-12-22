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
    public class TicketSoldController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: TicketSold
        public ActionResult Index()
        {
            var ticketSolds = db.TicketSolds.Include(t => t.CashRegister).Include(t => t.Session);
            return View(ticketSolds.ToList());
        }

        // GET: TicketSold/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSold ticketSold = db.TicketSolds.Find(id);
            if (ticketSold == null)
            {
                return HttpNotFound();
            }
            return View(ticketSold);
        }

        // GET: TicketSold/Create
        public ActionResult Create()
        {
            ViewBag.CashRegisterId = new SelectList(db.CashRegisters, "Id", "Employee");
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Id");
            return View();
        }

        // POST: TicketSold/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SessionId,PeopleId,Cost,PlaceNumber,CashRegisterId")] TicketSold ticketSold)
        {
            if (ModelState.IsValid)
            {
                db.TicketSolds.Add(ticketSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CashRegisterId = new SelectList(db.CashRegisters, "Id", "Employee", ticketSold.CashRegisterId);
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Id", ticketSold.SessionId);
            return View(ticketSold);
        }

        // GET: TicketSold/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSold ticketSold = db.TicketSolds.Find(id);
            if (ticketSold == null)
            {
                return HttpNotFound();
            }
            ViewBag.CashRegisterId = new SelectList(db.CashRegisters, "Id", "Employee", ticketSold.CashRegisterId);
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Id", ticketSold.SessionId);
            return View(ticketSold);
        }

        // POST: TicketSold/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SessionId,PeopleId,Cost,PlaceNumber,CashRegisterId")] TicketSold ticketSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CashRegisterId = new SelectList(db.CashRegisters, "Id", "Employee", ticketSold.CashRegisterId);
            ViewBag.SessionId = new SelectList(db.Sessions, "Id", "Id", ticketSold.SessionId);
            return View(ticketSold);
        }

        // GET: TicketSold/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketSold ticketSold = db.TicketSolds.Find(id);
            if (ticketSold == null)
            {
                return HttpNotFound();
            }
            return View(ticketSold);
        }

        // POST: TicketSold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketSold ticketSold = db.TicketSolds.Find(id);
            db.TicketSolds.Remove(ticketSold);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
