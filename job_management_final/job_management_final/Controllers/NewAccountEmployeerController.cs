using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using job_management_final;
using job_management_final.Models;

namespace job_management_final.Controllers
{
    public class NewAccountEmployeerController : Controller
    {
        private job_management_twoEntities db = new job_management_twoEntities();

        // GET: /NewAccountEmployeer/
        public ActionResult Index()
        {
            var employeers = db.employeers.Include(e => e.user);
            return View(employeers.ToList());
        }

        public JsonResult IsUserNameAvailable(string username)
        {
            return Json(!db.users.Any(user => user.username == username), JsonRequestBehavior.AllowGet);
        }

        // GET: /NewAccountEmployeer/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeer employeer = db.employeers.Find(id);
            if (employeer == null)
            {
                return HttpNotFound();
            }
            return View(employeer);
        }

        // GET: /NewAccountEmployeer/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.users, "id_user", "email");
            return View();
        }

        // POST: /NewAccountEmployeer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeerViewModel employeer1) //[Bind(Include="id_employeer,id_user,office_name,contact_number,office_address")] employeer employeer
        {
            if (db.users.Any(model => model.username == employeer1.userEmployeer.username))
            {
                ModelState.AddModelError("userEmployeer.username", "Ooops! Username is already be taken. try something new");
            }

            else if (db.users.Any(model => model.email == employeer1.userEmployeer.email))
            {
                ModelState.AddModelError("userEmployeer.email", "Ooops! this email is already be taken. try something new");
            }

            if (ModelState.IsValid)
            {
                employeer1.userEmployeer.user_role = "employeer";
                db.users.Add(employeer1.userEmployeer);
                employeer1.employeerEmployeer.id_user = employeer1.userEmployeer.id_user;
                db.employeers.Add(employeer1.employeerEmployeer);

                //db.employeers.Add(employeer);
                db.SaveChanges();
                //Login check = new Login();
                //check.username = employeer1.userEmployeer.username;
                //check.password = employeer1.userEmployeer.password;
                var user1 = new user();
                user1 = employeer1.userEmployeer;

                return RedirectToAction("Index", "Login", user1);
            }

            // ViewBag.id_user = new SelectList(db.users, "id_user", "email", employeer.id_user);
            return View(employeer1);
        }

        // GET: /NewAccountEmployeer/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeer employeer = db.employeers.Find(id);
            if (employeer == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", employeer.id_user);
            return View(employeer);
        }

        // POST: /NewAccountEmployeer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_employeer,id_user,office_name,contact_number,office_address")] employeer employeer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", employeer.id_user);
            return View(employeer);
        }

        // GET: /NewAccountEmployeer/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeer employeer = db.employeers.Find(id);
            if (employeer == null)
            {
                return HttpNotFound();
            }
            return View(employeer);
        }

        // POST: /NewAccountEmployeer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            employeer employeer = db.employeers.Find(id);
            db.employeers.Remove(employeer);
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
