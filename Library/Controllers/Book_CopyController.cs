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
    public class Book_CopyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book_Copy
        public ActionResult Index()
        {
            var book_Copy = db.Book_Copy.Include(b => b.Book);
            return View(book_Copy.ToList());
        }

        // GET: Book_Copy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Copy book_Copy = db.Book_Copy.Find(id);
            if (book_Copy == null)
            {
                return HttpNotFound();
            }
            return View(book_Copy);
        }

        // GET: Book_Copy/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName");
            return View();
        }

        // POST: Book_Copy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_CopyID,LendingStatus,Name,Description,BookID")] Book_Copy book_Copy)
        {
            if (ModelState.IsValid)
            {
                db.Book_Copy.Add(book_Copy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", book_Copy.BookID);
            return View(book_Copy);
        }

        // GET: Book_Copy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Copy book_Copy = db.Book_Copy.Find(id);
            if (book_Copy == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", book_Copy.BookID);
            return View(book_Copy);
        }

        // POST: Book_Copy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_CopyID,LendingStatus,Name,Description,BookID")] Book_Copy book_Copy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Copy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookName", book_Copy.BookID);
            return View(book_Copy);
        }

        // GET: Book_Copy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Copy book_Copy = db.Book_Copy.Find(id);
            if (book_Copy == null)
            {
                return HttpNotFound();
            }
            return View(book_Copy);
        }

        // POST: Book_Copy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Copy book_Copy = db.Book_Copy.Find(id);
            db.Book_Copy.Remove(book_Copy);
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
