using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class MessageBooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageBooks
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: MessageBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBook messageBook = db.Messages.Find(id);
            if (messageBook == null)
            {
                return HttpNotFound();
            }
            return View(messageBook);
        }

        // GET: MessageBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Dob,Message")] MessageBook messageBook)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messageBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageBook);
        }

        // GET: MessageBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBook messageBook = db.Messages.Find(id);
            if (messageBook == null)
            {
                return HttpNotFound();
            }
            return View(messageBook);
        }

        // POST: MessageBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Dob,Message")] MessageBook messageBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageBook);
        }

        // GET: MessageBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBook messageBook = db.Messages.Find(id);
            if (messageBook == null)
            {
                return HttpNotFound();
            }
            return View(messageBook);
        }

        // POST: MessageBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBook messageBook = db.Messages.Find(id);
            db.Messages.Remove(messageBook);
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
