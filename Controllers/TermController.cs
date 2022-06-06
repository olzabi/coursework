using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coursework.DAL;
using coursework.Models;

namespace coursework.Controllers
{
    public class TermController : Controller
    {
        private TermContext db = new TermContext();

        // GET: Term
        public ActionResult Index()
        {
            var termPapers = db.TermPapers;
            return View(termPapers.ToList());
        }

        // GET: Term/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermPaper termPaper = db.TermPapers.Find(id);
            if (termPaper == null)
            {
                return HttpNotFound();
            }
            return View(termPaper);
        }

        // GET: Term/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorId = new SelectList(db.Advisors, "AdvisorId", "LastName");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "LastName");
            return View();
        }

        // POST: Term/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermPaperID,StudentId,AdvisorId,Taken,Due,Grade,IsPassed")] TermPaper termPaper)
        {
            if (ModelState.IsValid)
            {
                db.TermPapers.Add(termPaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorId = new SelectList(db.Advisors, "AdvisorId", "LastName", termPaper.AdvisorId);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "LastName", termPaper.StudentId);
            return View(termPaper);
        }

        // GET: Term/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermPaper termPaper = db.TermPapers.Find(id);
            if (termPaper == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorId = new SelectList(db.Advisors, "AdvisorId", "LastName", termPaper.AdvisorId);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "LastName", termPaper.StudentId);
            return View(termPaper);
        }

        // POST: Term/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermPaperID,StudentId,AdvisorId,Taken,Due,Grade,IsPassed")] TermPaper termPaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termPaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorId = new SelectList(db.Advisors, "AdvisorId", "LastName", termPaper.AdvisorId);
            ViewBag.StudentID = new SelectList(db.Students, "StudentId", "LastName", termPaper.StudentId);
            return View(termPaper);
        }

        // GET: Term/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TermPaper termPaper = db.TermPapers.Find(id);
            if (termPaper == null)
            {
                return HttpNotFound();
            }
            return View(termPaper);
        }

        // POST: Term/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TermPaper termPaper = db.TermPapers.Find(id);
            db.TermPapers.Remove(termPaper);
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
