using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.Models.Libarary;

namespace Library.Controllers
{
    public class LendingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lending
        public ActionResult Index()
        {
            var lends = db.Lends.Include(l => l.Book_Copy).Include(l => l.Member);
            return View(lends.ToList());
        }

        // GET: Lending/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // GET: Lending/Create
        public ActionResult Create()
        {
            ViewBag.Book_CopyID = new SelectList(db.Book_Copy, "Book_CopyID", "Name");
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            return View();
        }

        // POST: Lending/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LendID,Book_CopyID,MemberID")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Lends.Add(lend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_CopyID = new SelectList(db.Book_Copy, "Book_CopyID", "Name", lend.Book_CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", lend.MemberID);
            return View(lend);
        }

        // GET: Lending/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_CopyID = new SelectList(db.Book_Copy, "Book_CopyID", "Name", lend.Book_CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", lend.MemberID);
            return View(lend);
        }

        // POST: Lending/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LendID,Book_CopyID,MemberID")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_CopyID = new SelectList(db.Book_Copy, "Book_CopyID", "Name", lend.Book_CopyID);
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", lend.MemberID);
            return View(lend);
        }

        // GET: Lending/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // POST: Lending/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lend lend = db.Lends.Find(id);
            db.Lends.Remove(lend);
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
