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
    public class NewAccountJobSeekerController : Controller
    {
        private job_management_twoEntities db = new job_management_twoEntities();

        // GET: /NewAccountJobSeeker/
        public ActionResult Index()
        {
            var employees = db.employees.Include(e => e.user);
            return View(employees.ToList());
        }

        // GET: /NewAccountJobSeeker/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /NewAccountJobSeeker/Create
        public ActionResult Create()
        {


            //ViewBag.id_user = new SelectList(db.users, "id_user", "email");

            JobSeekerViewModel jobseeker1 = new JobSeekerViewModel();
            return View(jobseeker1);
        }

        // POST: /NewAccountJobSeeker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobSeekerViewModel jobseeker1)                             //[Bind(Include="id_employee,id_user,age,sex,first_name,last_name,father_name,mother_name,contact_number,local_address,parmanent_address")] employee employee
        {

            if (db.users.Any(model => model.username == jobseeker1.userJobSeeker.username))
            {
                ModelState.AddModelError("userJobSeeker.username", "Ooops! Username is already be taken. try something new");
            }

            else if (db.users.Any(model => model.email == jobseeker1.userJobSeeker.email))
            {
                ModelState.AddModelError("userJobSeeker.email", "Ooops! this email is already be taken. try something new");
            }

            if (ModelState.IsValid)
            {
                jobseeker1.userJobSeeker.user_role = "jobseeker";
                db.users.Add(jobseeker1.userJobSeeker);
                //db.SaveChanges();
                jobseeker1.employeeJobSeeker.id_user = jobseeker1.userJobSeeker.id_user;
                db.employees.Add(jobseeker1.employeeJobSeeker);
                //db.SaveChanges();
                //jobseeker1.educationSSCJobseeker.id_employee = jobseeker1.employeeJobSeeker.id_employee;
                //db.educations.Add(jobseeker1.educationSSCJobseeker);
                //db.employees.Add(employee);
                db.SaveChanges();
                
                Login check = new Login();
                check.username = jobseeker1.userJobSeeker.username;
                check.password = jobseeker1.userJobSeeker.password;
                return RedirectToAction("Index", "Login", check);
               // return RedirectToAction("Index");
            }

            //ViewBag.id_user = new SelectList(db.users, "id_user", "email", employee.id_user);
            return View(jobseeker1);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(JobSeekerViewModel jobseeker1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.users.Add(jobseeker1.userJobSeeker);
        //        db.employees.Add(jobseeker1.employeeJobSeeker);
        //        db.educations.Add(jobseeker1.educationSSCJobseeker);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.users.Add(jobseeker1.userJobSeeker);
        //        //db.employees.Add(jobseeker1.employeeJobSeeker);
        //        //db.educations.Add(jobseeker1.educationSSCJobseeker);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}

        // GET: /NewAccountJobSeeker/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", employee.id_user);
            return View(employee);
        }

        // POST: /NewAccountJobSeeker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_employee,id_user,age,sex,first_name,last_name,father_name,mother_name,contact_number,local_address,parmanent_address")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.users, "id_user", "email", employee.id_user);
            return View(employee);
        }

        // GET: /NewAccountJobSeeker/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /NewAccountJobSeeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
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
