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
    public class InstructeurController : Controller
    {
        private Autorijschool3DbContext db = new Autorijschool3DbContext();

        // GET: Instructeur
        public ActionResult Index()
        {
            return View(db.Instructeurs.ToList());
        }

        // GET: Instructeur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructeur instructeur = db.Instructeurs.Find(id);
            if (instructeur == null)
            {
                return HttpNotFound();
            }
            return View(instructeur);
        }

        // GET: Instructeur/Create
        public ActionResult Create(int? id)
        {

            //list object van rijbewijzen
            //we hebben deze lijst nodig om hieruit de html in te vullen
           
          ViewBag.lijstAlleRijbewijzen = db.Rijbewijs.ToList();
            //voegen deze lijst met alle rijbewijzen toe
           //de lijst van rijbewijzen in instructeur zijn enkel de rijbewijzen die al toegevoegd zijn aan een instructeur
         return View();


        
        }

        // POST: Instructeur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //bind doen op het model, wilt zeggen dat: veldjes krijgen deze naam mee (case sensitive) email hang aan email instucteur,..
        //, int .. moet dezelfde naam hebben dat we meegegeven hebben in create van de list
        //int rijbewijs_id : dropdown meepakken en uitlezen door bind
        public ActionResult Create([Bind(Include = "ID,Familienaam,Voornaam,Adres,Gemeente")] Instructeur instructeur, int rijbewijs_id)
        {
            if (ModelState.IsValid)
            {

                //rijbewijs_id dat is meegegeven hierboven gaan zoeken in tabel
                Rijbewijs rijbewijs = db.Rijbewijs.Find(rijbewijs_id);

                //als dit nieuw rijbewijs niet null is, dan gaan we dat rijbewijs toevoegen.
                if (rijbewijs != null)
                    instructeur.TypeRijbewijzenLijst.Add(rijbewijs);
                //voegen dit toe aan de oorspronkelijke lijst

                db.Instructeurs.Add(instructeur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instructeur);
        }

        // GET: Instructeur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructeur instructeur = db.Instructeurs.Find(id);
            //zelfde als in create
            ViewBag.lijstAlleRijbewijzen = db.Rijbewijs.ToList();
            if (instructeur == null)
            {
                return HttpNotFound();
            }
            return View(instructeur);
        }

        // POST: Instructeur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Familienaam,Voornaam,Adres,Gemeente")] Instructeur instructeur, int rijbewijs_id)
        {
            if (ModelState.IsValid)
            {

                //rijbewijs_id dat is meegegeven hierboven gaan zoeken in tabel
                Rijbewijs rijbewijs = db.Rijbewijs.Find(rijbewijs_id);
                //we moeten ook de juiste, geselecteerde persoon in de db zoeken en dan aanpassen
                Instructeur instr = db.Instructeurs.Find(instructeur.ID);
                //als dit nieuw rijbewijs niet null is, dan gaan we dat rijbewijs toevoegen.
                if (rijbewijs != null)
                    instr.TypeRijbewijzenLijst.Add(rijbewijs);
                //voegen dit toe aan de oorspronkelijke lijst
                
                
                    db.SaveChanges();
                
                
                
                return RedirectToAction("Index");

            }
            return View(instructeur);
        }

        // GET: Instructeur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructeur instructeur = db.Instructeurs.Find(id);
            if (instructeur == null)
            {
                return HttpNotFound();
            }
            return View(instructeur);
        }

        // POST: Instructeur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructeur instructeur = db.Instructeurs.Find(id);
            db.Instructeurs.Remove(instructeur);
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


        public ActionResult VerwijderRijbewijs(int id, int idRijbewijs)
        {
            Instructeur instructeur = db.Instructeurs.Find(id);
            Rijbewijs rijbewijs = db.Rijbewijs.Find(idRijbewijs);

            instructeur.TypeRijbewijzenLijst.Remove(rijbewijs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
