using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.ApplicationModels;

namespace LibraryManagementSystem.Controllers.ApplicationControllers
{
    public class IssueBooksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: IssueBooks
        public ActionResult Index()
        {
            var issueBooks = db.IssueBooks.Include(i => i.Book).Include(i => i.Student);
            return View(issueBooks.ToList());
        }

        // GET: IssueBooks/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // GET: IssueBooks/Create
        public ActionResult Create()
        {
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: IssueBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueId,StudentId,BookId,IssueDate,ReturnDate")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.IssueBooks.Add(issueBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", issueBook.BookId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", issueBook.StudentId);
            return View(issueBook);
        }

        // GET: IssueBooks/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", issueBook.BookId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", issueBook.StudentId);
            return View(issueBook);
        }

        // POST: IssueBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueId,StudentId,BookId,IssueDate,ReturnDate")] IssueBook issueBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle", issueBook.BookId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName", issueBook.StudentId);
            return View(issueBook);
        }

        // GET: IssueBooks/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBook issueBook = db.IssueBooks.Find(id);
            if (issueBook == null)
            {
                return HttpNotFound();
            }
            return View(issueBook);
        }

        // POST: IssueBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            IssueBook issueBook = db.IssueBooks.Find(id);
            db.IssueBooks.Remove(issueBook);
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
