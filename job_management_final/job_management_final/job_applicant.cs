//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace job_management_final
{
    using System;
    using System.Collections.Generic;
    
    public partial class job_applicant
    {
        public long id_job_applicant { get; set; }
        public long id_employee { get; set; }
        public long id_job_circular { get; set; }
    
        public virtual employee employee { get; set; }
        public virtual job_circular job_circular { get; set; }
    }
}
