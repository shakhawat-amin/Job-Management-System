using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using job_management_final.Models;
using MySql.Data.MySqlClient;

namespace job_management_final.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private job_management_twoEntities db = new job_management_twoEntities();
        private user userlog1 = new user();
        private JobSeekerViewModel jobseekerviewmodel1 = new JobSeekerViewModel();
        private employee employeelog1 = new employee();
        private employeer employeerlog1 = new employeer();
        employee employeelog2 = new employee();
        public ActionResult Index()
        {
            Login check = new Login();
            return View(check);
        }

        [HttpPost]
        public ActionResult Index(Login check)
        {

            if (db.users.Any(model => model.username == check.username))
            {
                //var userlogs = db.users.Where(model => model.password == check.password);
                var userlogs = from us in db.users
                               where us.username == check.username
                               select us;

                userlog1 = userlogs.First();
                if (userlog1.password == check.password)
                {
                    if (ModelState.IsValid)
                    {
                        if (userlog1.user_role.Equals("jobseeker"))
                        {


                            return RedirectToAction("Details_JobSeeker", userlog1);

                            //return View(jobseekerviewmodel1);
                            //return Details_JobSeeker(check);

                        }
                        else
                        {
                            //    EmployeerViewModel employeerviewmodel1 = new EmployeerViewModel();
                            //    var emp = db.employeers.Where(model => model.id_user == userlog1.id_user);
                            //    employeerlog1 = emp.FirstOrDefault();
                            //    employeerviewmodel1.employeerEmployeer = employeerlog1;
                            //    employeerviewmodel1.userEmployeer = userlog1;
                            //    Object A = employeerviewmodel1;
                            return RedirectToAction("Details_Employeer", userlog1);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "Wrong Password");
                }

            }

            else
                ModelState.AddModelError("username", "Wrong username");



            return View(check);

        }

        //public ActionResult Details_JobSeeker(Login check)
        //{
        //    JobSeekerViewModel jobseekerviewmodel1 = new JobSeekerViewModel();;
        //    jobseekerviewmodel1.userJobSeeker = userlog1;
        //    jobseekerviewmodel1.employeeJobSeeker = employeelog2;
        //    return View(jobseekerviewmodel1);
        //}
        public ActionResult Details_JobSeeker(user User)
        {
            var employ = from emp in db.employees
                         where emp.id_user == User.id_user
                         select emp;
            employeelog2 = employ.First();

            jobseekerviewmodel1.employeeJobSeeker = employ.First() as employee;

            jobseekerviewmodel1.userJobSeeker = User as user;
            return View(jobseekerviewmodel1);

            // return View(jobseekerviewmodel1);
        }
        public ActionResult Details_JobSeeker_test(Login js)
        {
            return View(js);
        }
        public ActionResult Details_Employeer(user user1)
        {
            var employeers = from emp in db.employeers
                             where emp.id_user == user1.id_user
                             select emp;
            var employeer1 = employeers.First();
            var employeerviewmodel1 = new EmployeerViewModel();

            employeerviewmodel1.employeerEmployeer = employeer1;
            employeerviewmodel1.userEmployeer = user1;
            //if (userlog1.id_user == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //employee employee = db.employees.Find(id);
            //if (employee. == null)
            //{
            //    return HttpNotFound();
            //}                      
            return View(employeerviewmodel1);
        }

        public ActionResult Education_JobSeeker(employee employee1)
        {
            //var educationlogs = from edu in db.educations where
            //                    edu.id_employee == employee1.id_employee
            ////                    select edu;
            education education1 = new education();
            education1.id_employee = employee1.id_employee;
            //educationlog1.id_employee = ;
            //educationlog1.id_employee = employeelog1.id_employee;
            return View(education1);//educationlog1);



        }
        [HttpPost]
        public ActionResult Education_JobSeeker(education education1)
        {
            //System.Linq.IQueryable education1 = db.educations.Where(model => model.id_employee == educationJobseekerlog1.id_employee);
            //var education1 = db.educations.Any(model => model.id_employee == educationJobseekerlog1.id_employee);
            //if (db.users.Any(model => model.email == jobseeker1.userJobSeeker.email))

            education1.degree_name = education1.degree_name.ToLower();
            var educationlogs = from edu in db.educations
                                where edu.id_employee == education1.id_employee
                                select edu;

            foreach (education checkedu in educationlogs)
            {
                if (checkedu.degree_name == education1.degree_name)
                {
                    ModelState.AddModelError("degree_name", "Ooops! you have given your this degree info. give ur new degree");
                    break;
                }
            }
            if (education1.score > education1.scale)
            {
                ModelState.AddModelError("score", "Ooops! score can't be greater than scale. plz give correct info!");
            }
            if (ModelState.IsValid)
            {
                db.educations.Add(education1);
                db.SaveChanges();
                var employ = from emp in db.employees
                             where emp.id_employee == education1.id_employee
                             select emp;
                employee employee1 = employ.First();
                var userlogs = from us in db.users
                               where us.id_user == employee1.id_user
                               select us;
                user user1 = userlogs.First();
                return RedirectToAction("Details_JobSeeker", user1);

            }
            return View(education1);

        }

        public ActionResult Show_Education_JobSeeker(employee employee1)
        {
            IEnumerable<education> educations = from edu in db.educations
                                                where edu.id_employee == employee1.id_employee
                                                select edu;
            if (0 == educations.Count())
            {
                var userlogs = from us in db.users
                               where us.id_user == employee1.id_user
                               select us;
                user user1 = userlogs.First();
                return RedirectToAction("Details_JobSeeker", user1);
            }
            return View(educations);
        }

        public ActionResult Show_Education_JobSeeker2(education education1)
        {
            var employ = from emp in db.employees
                         where emp.id_employee == education1.id_employee
                         select emp;
            employee employee1 = employ.First();
            var userlogs = from us in db.users
                           where us.id_user == employee1.id_user
                           select us;
            user user1 = userlogs.First();
            return RedirectToAction("Details_JobSeeker", user1);
        }

        public ActionResult Job_tags_JobSeeker(employee employee1)
        {
            var jobseekertag1 = new employee_tag();
            jobseekertag1.id_employee = employee1.id_employee;
            return View(jobseekertag1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Job_tags_JobSeeker(employee_tag tag1)
        {
            tag1.tag_name = tag1.tag_name.ToLower();
            var tags = from jtag in db.employee_tag
                       where jtag.id_employee == tag1.id_employee
                       select jtag;
            var employ = from emp in db.employees
                         where emp.id_employee == tag1.id_employee
                         select emp;
            employee employee1 = employ.First();
            var userlogs = from us in db.users
                           where us.id_user == employee1.id_user
                           select us;
            user user1 = userlogs.First();
            foreach (employee_tag tag in tags)
            {
                if (tag.tag_name == tag1.tag_name)
                    ModelState.AddModelError("tag_name", "You have added this tag. add new tag");
            }
            if (ModelState.IsValid)
            {
                db.employee_tag.Add(tag1);
                db.SaveChanges();
                return RedirectToAction("Details_JobSeeker", user1);
            }
            else
                return View(tag1);
        }
        public ActionResult Show_Job_tags(employee employee1)
        {
            var tags = from jtag in db.employee_tag
                       where jtag.id_employee == employee1.id_employee
                       select jtag;
            if (0 == tags.Count())
            {
                var userlogs = from us in db.users
                               where us.id_user == employee1.id_user
                               select us;
                user user1 = userlogs.First();
                return RedirectToAction("Details_JobSeeker", user1);
            }
            return View(tags);
        }
        public ActionResult Show_Job_tags2(employee_tag employee_tag1)
        {
            var employ = from emp in db.employees
                         where emp.id_employee == employee_tag1.id_employee
                         select emp;
            var employee1 = employ.First();
            var userlogs = from us in db.users
                           where us.id_user == employee1.id_user
                           select us;
            var user1 = userlogs.First();
            return RedirectToAction("Details_JobSeeker", user1);
        }

        public ActionResult search_jobs_jobseeker(employee employee1)
        {
            JobAppliedViewModel JobAppliedViewModel1 = new JobAppliedViewModel();
            JobAppliedViewModel1.EmployeeJobSeeker = employee1;
            var employee_tags = from jstag in db.employee_tag
                                where jstag.id_employee == employee1.id_employee
                                select jstag;
            Boolean check;
            var jcs = (from all in db.job_circular
                          select all).ToList();
            List<job_circular> jobCirculars = new List<job_circular>();

            foreach (job_circular jc in jcs)
            {
                check = false;
                var tags = (from tag in db.job_circular_tag
                            where tag.id_job_circular == jc.id_job_circular
                            select tag).ToList();
                    

                foreach (var jctag in tags)
                {
                    foreach (var emptag in employee_tags)
                    {
                        if (emptag.tag_name == jctag.tag_name)
                        {
                            //JobAppliedViewModel1.job_circularsJobSeeker.Add(jc);
                            jobCirculars.Add(jc);
                            check = true;
                            break;
                        }
                    }

                    if (check)
                        break;
                }

            }
            JobAppliedViewModel1.job_circularsJobSeeker = jobCirculars;

            return View(JobAppliedViewModel1);
        }










        public ActionResult Job_Circular_employeer(employeer employeer1)
        {
            job_circular job_circular1 = new job_circular();
            job_circular1.id_employeer = employeer1.id_employeer;
            job_circular1.deadline = DateTime.Now.AddDays(7);
            return View(job_circular1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult job_circular_employeer(job_circular job_circular1)
        {
            //var job_circulars = from jc in db.job_circular
            //                    where jc.id_employeer == job_circular1.id_employeer
            //                    select jc;
            if (null == job_circular1.title)
            {
                ModelState.AddModelError("title", "tittle Can't be null. give a nice title");
            }
            if (job_circular1.deadline < DateTime.Now.AddDays(5))
            {
                if (job_circular1.deadline < DateTime.Now)
                    ModelState.AddModelError("deadline", "your deadline is over before giving circular. please give a valid date time");
                else
                    ModelState.AddModelError("deadline", "You are trying to give a job circular less than 5 days. please add more time. Thank u");
            }
            if (job_circular1.experience != null && job_circular1.experience < 0)
            {
                ModelState.AddModelError("experience", "Experience Can't be negative");
            }
            if (job_circular1.vacancy < 0 || job_circular1.vacancy == null)
            {
                ModelState.AddModelError("vacancy", "Vacancy can't be null or less than zero");
            }
            if (ModelState.IsValid)
            {
                db.job_circular.Add(job_circular1);
                db.SaveChanges();

                // job_circular1 = job_circular1;
                // var job_circular2 = new job_circular();
                // job_circular2.id_job_circular = job_circular1.id_job_circular;
                return RedirectToAction("job_circular_tag", job_circular1);
            }
            return View(job_circular1);

        }

        public ActionResult job_circular_tag(job_circular job_circular1)
        {
            var job_circular_tag1 = new job_circular_tag();
            job_circular_tag1.id_job_circular = job_circular1.id_job_circular;
            return View(job_circular_tag1);
        }
        [HttpPost]
        public ActionResult job_circular_tag(job_circular_tag job_circular_tag1, string finish, string next_tag)
        {
            job_circular_tag1.tag_name = job_circular_tag1.tag_name.ToLower();
            var job_circulars = from jct in db.job_circular
                                where jct.id_job_circular == job_circular_tag1.id_job_circular
                                select jct;
            var job_circular1 = job_circulars.First();
            var job_circular_tags = from jobc in db.job_circular_tag
                                    where jobc.id_job_circular == job_circular_tag1.id_job_circular
                                    select jobc;
            if (job_circular_tag1.tag_name == null)
            {
                ModelState.AddModelError("tag_name", "Please enter a job tag");
            }
            foreach (job_circular_tag jct in job_circular_tags)
            {
                if (jct.tag_name == job_circular_tag1.tag_name)
                {
                    ModelState.AddModelError("tag_name", "This tag has been added before");
                    return RedirectToAction("job_circular_tag", job_circular1);
                }
            }
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(finish))
                {
                    db.job_circular_tag.Add(job_circular_tag1);
                    db.SaveChanges();

                    //var job_circulars = from jc in db.job_circular
                    //                    where jc.id_job_circular == job_circular_tag1.id_job_circular
                    //                    select jc;
                    //var job_circular1 = job_circulars.First();
                    var employ = from emp in db.employeers
                                 where emp.id_employeer == job_circular1.id_employeer
                                 select emp;
                    var employee1 = employ.First();
                    var users = from us in db.users
                                where us.id_user == employee1.id_user
                                select us;
                    var user1 = users.First();
                    return RedirectToAction("Details_Employeer", user1);
                }
                if (!string.IsNullOrEmpty(next_tag))
                {
                    db.job_circular_tag.Add(job_circular_tag1);
                    db.SaveChanges();
                    // var id1 = job_circular_tag1.id_job_circular;
                    return RedirectToAction("job_circular_tag", job_circular1);
                }
            }
            return View(job_circular_tag1);
        }

        public ActionResult Show_Jobs_Employeer(employeer employeer1)                //id_employeer
        {
            var job_circulars = from jc in db.job_circular
                                where jc.id_employeer == employeer1.id_employeer
                                select jc;
            return View(job_circulars);
        }


        public ActionResult Apply_JobSeeker (long employee_id, long jc_id)
        {
            var job_applied_JobSeeker = from jc in db.job_applied
                                        where jc.id_employee == employee_id
                                        select jc;
            Boolean check = false;
            foreach (var item in job_applied_JobSeeker)
            {
                if (item.id_job_circular == jc_id)
                    check = true;
            }
            var employ = from emp in db.employees
                         where emp.id_employee == employee_id
                         select emp;
            var employee1 = employ.First();
            var users = from us in db.users
                        where us.id_user == employee1.id_user
                        select us;
            var user1 = users.First();
            if (check)
            {
                return View(employee1);      //view add korte hobe
            }
            else
            {
                job_applied job_applied1 = new job_applied();
                job_applied1.id_employee = employee_id;
                job_applied1.id_job_circular = jc_id;
                job_applied1.status = "Pending";
                db.job_applied.Add(job_applied1);
                job_applicant job_applicant1 = new job_applicant();
                job_applicant1.id_employee = employee_id;
                job_applicant1.id_job_circular = jc_id;
                db.job_applicant.Add(job_applicant1);
                db.SaveChanges();
                
                return RedirectToAction("Details_JobSeeker", user1);
            }
        }


        public ActionResult Applied_Jobs(employee employee1)
        {
            var jobs = (from j in db.job_applied
                       where j.id_employee == employee1.id_employee
                       select j).ToList();
            //var job_circulars = (from jc in db.job_circular
            //                        select jc).Last();
            List<AppliedJobsViewModel> AppliedJobsViewModel1 = new List<AppliedJobsViewModel>();
            
            foreach (var job in jobs)
            {
                var AppliedJobsViewModelTemp = new AppliedJobsViewModel();
                var job_circular1 = new job_circular();
                var job_circularTemp = (from jct in db.job_circular                              //
                                       where jct.id_job_circular == job.id_job_circular         //
                                       select jct).ToList();                                              //
                job_circular1 = job_circularTemp.First();                                       //
                AppliedJobsViewModelTemp.EmployeeJobSeeker = employee1;
                AppliedJobsViewModelTemp.job_applied1 = job;
                AppliedJobsViewModelTemp.job_circular1 = job_circular1;

                AppliedJobsViewModel1.Add(AppliedJobsViewModelTemp);
            }
            return View(AppliedJobsViewModel1);
        }

        public ActionResult Job_Applicants(long? id_job_circular)
        {
            var job_circular = (from jc in db.job_circular
                                where jc.id_job_circular == id_job_circular
                                select jc).First();
            var job_applicants = (from ja in db.job_applied
                                 where ja.id_job_circular == id_job_circular
                                 select ja).ToList();
            if (job_applicants.Count() == 0)
            {
                var employee1 = (from emp in db.employeers
                                 where emp.id_employeer == job_applicants.First().id_employee
                                 select emp).First();
                RedirectToAction("Job_Applicant2", employee1);
            }
            var jobApplicantViewModelList = new List<JobApplicantViewModel>();
            var jobApplicantViewModelTemp = new JobApplicantViewModel();
            foreach (var job in job_applicants)
            {
                jobApplicantViewModelTemp.job_circular1 = job_circular;
                jobApplicantViewModelTemp.employee1 = (from emp in db.employees
                                                       where emp.id_employee == job.id_employee
                                                       select emp).First();
                jobApplicantViewModelTemp.job_applied1 = job;
                jobApplicantViewModelList.Add(jobApplicantViewModelTemp);
            }



            return View(jobApplicantViewModelList);

        }

        public ActionResult Job_Applicant_2(long? job_circular1_id, long? job_applied1_id)
        {
            var job_applied = (from ja in db.job_applied
                               where ja.id_job_applied == job_applied1_id
                               select ja).First();
            job_applied.status = "Called";
            db.SaveChanges();
            return RedirectToAction("Job_Applicants", job_circular1_id);
        }

        public ActionResult Search_Attribute(employee employee1)
        {
            Search search1 = new Search();
            search1.id_employee = employee1.id_employee;

            return View(search1);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Search_Attribute(Search search1)
        {
            if (search1.AttributeName == null)
                ModelState.AddModelError("AttributeName", "Select an attribute");
            if(search1.SearchName == null)
                ModelState.AddModelError("SearchName", "Type something to search");
            if (ModelState.IsValid)
            {
                return RedirectToAction("Search_Attribute_result", search1);
            }
            return View(search1);
        }
        public ActionResult Search_Attribute_result (Search search1)
        {
            JobAppliedViewModel jobAppliedViewModel1 = new JobAppliedViewModel();

            var employees = (from emp in db.employees
                             where emp.id_employee == search1.id_employee
                             select emp);
            var employee1 = employees.First();
            jobAppliedViewModel1.EmployeeJobSeeker = employee1;
            if (search1.AttributeName == "Office")
            {

                var employeers = (from emp in db.employeers
                                  where emp.office_name == search1.SearchName
                                  select emp).ToList();
                if (!employeers.Any())
                {
                    //ModelState.AddModelError("SearchName", "Nothing Found");
                    return RedirectToAction("Search_Attribute_result_Error", search1);                   //
                }
                var employeer1 = employeers.First();
                var job_circulars = (from jc in db.job_circular
                                     where jc.id_employeer == employeer1.id_employeer
                                     select jc).ToList();
                
                jobAppliedViewModel1.job_circularsJobSeeker = job_circulars;
                return View(jobAppliedViewModel1);
                }

            else if (search1.AttributeName == "Tittle")
            {
                var Job_circulars = (from jc in db.job_circular
                                     where jc.title == search1.SearchName
                                     select jc).ToList();
                if (!Job_circulars.Any())
                {
                    return RedirectToAction("Search_Attribute_result_Error", search1);
                }
                jobAppliedViewModel1.job_circularsJobSeeker = Job_circulars;
                return View(jobAppliedViewModel1);

            }
            else if (search1.AttributeName == "Salary")
            {
                var job_circulars = (from jc in db.job_circular
                                     where jc.salary == search1.SearchName
                                     select jc).ToList();
                if (!job_circulars.Any())
                {
                    return RedirectToAction("Search_Attribute_result_Error", search1);
                }
                jobAppliedViewModel1.job_circularsJobSeeker = job_circulars;
                return View(jobAppliedViewModel1);
            }
            
            
            return View(jobAppliedViewModel1);
        }


        public ActionResult Top_Trend (employee employee1)
        {
            List<Top_Trend_Model> TrendModel = new List<Top_Trend_Model>();
              
            var job_circulars = (from jc in db.job_circular
                                  select jc).ToList();
              foreach(var job in job_circulars)
              {
                  var trendModelTemp = new Top_Trend_Model();
                  trendModelTemp.applicant_count = (from c in db.job_applied
                                                    where c.id_job_circular == job.id_job_circular
                                                    select c).Count();
                   trendModelTemp.job_circular1 = job;
                  trendModelTemp.employee1 = employee1;
                  TrendModel.Add(trendModelTemp);
              }
            TrendModel = TrendModel.OrderByDescending(model => model.applicant_count).ToList();
            return View(TrendModel);
        }


        //public ActionResult Search_Attribute_result_Error(Search search1)
        //{

        //}

        //public ActionResult Edit_Jobs_Employeer(job_circular job_circular1)
        //{
        //    return View(job_circular1);
        //}

        //[HttpPost]
        //public ActionResult Edit_Jobs_Employeer(job_circular job_circular1)
        //{
 
        //}



    }
}




















