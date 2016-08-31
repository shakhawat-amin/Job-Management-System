using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job_management_final.Models
{
    public class JobAppliedViewModel
    {
        public employee EmployeeJobSeeker { get; set;}
        public List<job_circular> job_circularsJobSeeker { get; set; }

        public job_applied job_appliedJobSeeker { get; set; }
    }
}