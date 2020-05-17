using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Your_Petition.Models;

/**
 * the controler derives from model Petition using PetitionDBContext. This is "MVC5 Controler with views, using Entity Framework".
 * The controler utomatically generates the views  capable of displaying editing and generating petitions - CRUD views.
 **/



namespace Your_Petition.Controllers
{
    [Authorize] /**authorisation ansures that the content of the controler can only be accesed once the user has been succesfullu logged in **/
    public class PetitionsController : Controller
    {
        private PetitionDBContext db = new PetitionDBContext();

        // GET: Petitions
        public ActionResult Index(string searchString)

        {
            /**
             * LINQ query to select petitions
             **/
            var petitions = from m in db.Petitons
                            select m;
            /**
             * Add search
             **/
            if (!String.IsNullOrEmpty(searchString))
            {
                petitions = petitions.Where(s => s.Title.Contains(searchString)); /**Lamda Expression in order to check if the searchString can be found in the data**/
            }
            //var c = db.Petitons.Where(r => r.OwnerName == User.Identity.Name);
            return View(petitions);
        }

        /**
          * Using Details method in order to diplay the details of the datbase - View: Views\Petitions\Details
          * "id" parameter is passed as route data
        **/


        // GET: Petitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petitons.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        /**
          * Using Create method in order to create new petitions - View: Views\Petitions\Create
         **/

        // GET: Petitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Petitions/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Discription,Category,OwnerName")] Petition petition)
        {
            if (ModelState.IsValid)
            {
                db.Petitons.Add(petition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petition);
        }

        /** 
          * Using Edit method in order to edit  existing petitions - View: Views\Petitions\Delete
        **/


        // GET: Petitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petitons.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        // POST: Petitions/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Discription,Category,OwnerName")] Petition petition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petition);
        }

        /** 
        * Using Delete methods in order to delete  existing petitions - View: Views\Petitions\Edit
        **/


        // GET: Petitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Petition petition = db.Petitons.Find(id);
            if (petition == null)
            {
                return HttpNotFound();
            }
            return View(petition);
        }

        // POST: Petitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Petition petition = db.Petitons.Find(id);
            db.Petitons.Remove(petition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /**
         * Implement a Dispose method to release unmanaged resources used by your application.
         **/

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
