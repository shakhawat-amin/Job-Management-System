using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_management_final.Models
{
    public class Search
    {
        public long? id_employee { get; set; }
        public string AttributeName { get; set; }
        public string SearchName { get; set; }
    }
}