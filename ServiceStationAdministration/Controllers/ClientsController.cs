using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceStationAdministration.DAL;
using ServiceStationAdministration.Models;

namespace ServiceStationAdministration.Controllers
{
    public class ClientsController : Controller
    {
        private StationContext db = new StationContext();

        // GET: Clients
        public ActionResult Index(string sortOrder, string searchStringFirstName, string searchStringLastName)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var clients = from c in db.Clients
                           select c;

            if (!String.IsNullOrEmpty(searchStringFirstName) && !String.IsNullOrEmpty(searchStringLastName))
            {
                clients = clients.Where(c => c.Name.FirstName.Contains(searchStringFirstName)
                                       && c.Name.LastName.Contains(searchStringLastName));
            }
            else if (!String.IsNullOrEmpty(searchStringFirstName))
            {
                clients = clients.Where(c => c.Name.FirstName.Contains(searchStringFirstName));
            }
            else if (!String.IsNullOrEmpty(searchStringLastName))
            {
                clients = clients.Where(c => c.Name.LastName.Contains(searchStringLastName));
            }
            if (clients.Count() == 0)
            {
                return View("NoClientsFound");
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(c => c.Name.LastName);
                    break;
                case "":
                    clients = clients.OrderBy(c => c.Name.LastName);
                    break;
                default:
                    clients = clients.OrderBy(c => c.Name.LastName);
                    break;
            }
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateOfBirth,Address,PhoneNumber,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateOfBirth,Address,PhoneNumber,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = client.ID});
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false  )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. It is obviously exist some cars or orders assigned to this client. You can only delete clients without any cars nor orders.";
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Client client = db.Clients.Find(id);
                db.Clients.Remove(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
