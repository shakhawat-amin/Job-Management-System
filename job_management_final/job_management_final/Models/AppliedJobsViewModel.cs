using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job_management_final.Models
{
    public class AppliedJobsViewModel
    {
        public job_applied  job_applied1 { get; set; }
        public job_circular job_circular1 { get; set; }

        public employee EmployeeJobSeeker { get; set; }
    }
}