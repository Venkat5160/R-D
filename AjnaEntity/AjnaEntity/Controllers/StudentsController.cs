using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjnaEntity.DBLayer;
using AjnaEntity.Models;
using System.Data.Entity.Infrastructure;

namespace AjnaEntity.Controllers
{
    public class StudentsController : Controller
    {
        private AjnaContext db = new AjnaContext();

        // GET: Students
        public ActionResult Index(string sortOrder,string searchString)
        {
            ViewBag.Namesort = string.IsNullOrEmpty(sortOrder)?"name_desc":"";
            ViewBag.DateSort = sortOrder == "Date" ? "Date_desc" : "Date";
            var students = from s in db.Students
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                students=students.Where(s=>s.LastName.Contains(searchString)||s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc": students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date": students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "Date_desc": students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students=students.OrderBy(s=>s.LastName);
                    break;
            }
          var lst=  students.ToList();
            //return View(db.Students.ToList());
          return View(lst);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            try
            {
            }
            catch (RetryLimitExceededException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("", new { id = id, saveChangesError = true });
            }
            //return RedirectToAction("Index");
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
