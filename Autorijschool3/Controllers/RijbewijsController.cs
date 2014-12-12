using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Autorijschool3.Models;

namespace Autorijschool3.Controllers
{
    public class RijbewijsController : Controller
    {
        private Autorijschool3DbContext db = new Autorijschool3DbContext();

        // GET: Rijbewijs
        public ActionResult Index()
        {
            return View(db.Rijbewijs.ToList());
        }

        // GET: Rijbewijs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rijbewijs rijbewijs = db.Rijbewijs.Find(id);
            if (rijbewijs == null)
            {
                return HttpNotFound();
            }
            return View(rijbewijs);
        }

        // GET: Rijbewijs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rijbewijs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naam")] Rijbewijs rijbewijs)
        {
            if (ModelState.IsValid)
            {
                db.Rijbewijs.Add(rijbewijs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rijbewijs);
        }

        // GET: Rijbewijs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rijbewijs rijbewijs = db.Rijbewijs.Find(id);
            if (rijbewijs == null)
            {
                return HttpNotFound();
            }
            return View(rijbewijs);
        }

        // POST: Rijbewijs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naam")] Rijbewijs rijbewijs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rijbewijs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rijbewijs);
        }

        // GET: Rijbewijs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rijbewijs rijbewijs = db.Rijbewijs.Find(id);
            if (rijbewijs == null)
            {
                return HttpNotFound();
            }
            return View(rijbewijs);
        }

        // POST: Rijbewijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rijbewijs rijbewijs = db.Rijbewijs.Find(id);
            db.Rijbewijs.Remove(rijbewijs);
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
