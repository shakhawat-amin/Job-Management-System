using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace job_management_final.Controllers
{
    public class NewAccountController : Controller
    {
        private job_management_twoEntities db = new job_management_twoEntities();
        //
        // GET: /NewAccount/
        public ActionResult RegisterRole()
        {
            return View();
        }



        //public ActionResult RegisterEmployee()
        //{
        //    return View();
        //}

        //public ActionResult RegisterJobSeeker()
        //{
        //    return View();
        //}

    }
}