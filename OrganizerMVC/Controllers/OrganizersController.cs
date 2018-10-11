using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrganizerMVC.Models;

namespace OrganizerMVC.Controllers
{
    public class OrganizersController : BaseController
    {
        // GET: Organizers
        public ActionResult Index()
        {
            var organizers = DbContext.Organizers.Include(o => o.User);
            return View(organizers.ToList());
        }

        // GET: Organizers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = DbContext.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // GET: Organizers/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(DbContext.Users, "Id", "Email");
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,UserId,CreationDate")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                organizer.Id = Guid.NewGuid();
                DbContext.Organizers.Add(organizer);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(DbContext.Users, "Id", "Email", organizer.UserId);
            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = DbContext.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(DbContext.Users, "Id", "Email", organizer.UserId);
            return View(organizer);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,UserId,CreationDate")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(organizer).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(DbContext.Users, "Id", "Email", organizer.UserId);
            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = DbContext.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Organizer organizer = DbContext.Organizers.Find(id);
            DbContext.Organizers.Remove(organizer);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
