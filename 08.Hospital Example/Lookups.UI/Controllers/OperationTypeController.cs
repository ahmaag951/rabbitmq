using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lookups.DAL;

namespace Lookups.UI.Controllers
{
    public class OperationTypeController : Controller
    {
        private Hospital_LookupsEntities db = new Hospital_LookupsEntities();

        // GET: /OperationType/
        public ActionResult Index()
        {
            return View(db.OperationTypes.ToList());
        }

        // GET: /OperationType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationtype = db.OperationTypes.Find(id);
            if (operationtype == null)
            {
                return HttpNotFound();
            }
            return View(operationtype);
        }

        // GET: /OperationType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OperationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] OperationType operationtype)
        {
            if (ModelState.IsValid)
            {
                db.OperationTypes.Add(operationtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operationtype);
        }

        // GET: /OperationType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationtype = db.OperationTypes.Find(id);
            if (operationtype == null)
            {
                return HttpNotFound();
            }
            return View(operationtype);
        }

        // POST: /OperationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] OperationType operationtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operationtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operationtype);
        }

        // GET: /OperationType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationType operationtype = db.OperationTypes.Find(id);
            if (operationtype == null)
            {
                return HttpNotFound();
            }
            return View(operationtype);
        }

        // POST: /OperationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperationType operationtype = db.OperationTypes.Find(id);
            db.OperationTypes.Remove(operationtype);
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
