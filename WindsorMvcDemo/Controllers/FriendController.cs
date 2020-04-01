using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WindsorMvcDemo.Models;

namespace WindsorMvcDemo.Controllers
{
    public class FriendController : Controller
    {
        // private FriendsEntities db = new FriendsEntities();
        private FriendsEntities db;
        public FriendController(FriendsEntities _db)
        {
            db = _db;
        }
        // GET: Friend
        public ActionResult Index()
        {
            return View(db.FriendTables.ToList());
        }

        // GET: Friend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendTable friendTable = db.FriendTables.Find(id);
            if (friendTable == null)
            {
                return HttpNotFound();
            }
            return View(friendTable);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,FriendName,Place")] FriendTable friendTable)
        {
            if (ModelState.IsValid)
            {
                db.FriendTables.Add(friendTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friendTable);
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendTable friendTable = db.FriendTables.Find(id);
            if (friendTable == null)
            {
                return HttpNotFound();
            }
            return View(friendTable);
        }

        // POST: Friend/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,FriendName,Place")] FriendTable friendTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendTable);
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendTable friendTable = db.FriendTables.Find(id);
            if (friendTable == null)
            {
                return HttpNotFound();
            }
            return View(friendTable);
        }

        // POST: Friend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FriendTable friendTable = db.FriendTables.Find(id);
            db.FriendTables.Remove(friendTable);
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
