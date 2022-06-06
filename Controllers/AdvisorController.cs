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
    public class AdvisorController : Controller
    {
        private TermContext db = new TermContext();

        // GET: Advisor
        public ActionResult Index()
        {
            return View(db.Advisors.ToList());
        }

        // GET: Advisor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisors.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // GET: Advisor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advisor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvisorId,LastName,FirstMidName,Position")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                db.Advisors.Add(advisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advisor);
        }

        // GET: Advisor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisors.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // POST: Advisor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvisorId,LastName,FirstMidName,Position")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advisor);
        }

        // GET: Advisor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advisor advisor = db.Advisors.Find(id);
            if (advisor == null)
            {
                return HttpNotFound();
            }
            return View(advisor);
        }

        // POST: Advisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advisor advisor = db.Advisors.Find(id);
            db.Advisors.Remove(advisor);
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
