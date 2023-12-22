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
    public class CashRegisterController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: CashRegister
        public ActionResult Index()
        {
            return View(db.CashRegisters.ToList());
        }

        // GET: CashRegister/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashRegister cashRegister = db.CashRegisters.Find(id);
            if (cashRegister == null)
            {
                return HttpNotFound();
            }
            return View(cashRegister);
        }

        // GET: CashRegister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CashRegister/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartWorking,EndWorking,Employee")] CashRegister cashRegister)
        {
            if (ModelState.IsValid)
            {
                db.CashRegisters.Add(cashRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cashRegister);
        }

        // GET: CashRegister/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashRegister cashRegister = db.CashRegisters.Find(id);
            if (cashRegister == null)
            {
                return HttpNotFound();
            }
            return View(cashRegister);
        }

        // POST: CashRegister/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartWorking,EndWorking,Employee")] CashRegister cashRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cashRegister);
        }

        // GET: CashRegister/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashRegister cashRegister = db.CashRegisters.Find(id);
            if (cashRegister == null)
            {
                return HttpNotFound();
            }
            return View(cashRegister);
        }

        // POST: CashRegister/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CashRegister cashRegister = db.CashRegisters.Find(id);
            db.CashRegisters.Remove(cashRegister);
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
