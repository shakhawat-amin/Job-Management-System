﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class job_management_twoEntities : DbContext
    {
        public job_management_twoEntities()
            : base("name=job_management_twoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<education> educations { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<employee_tag> employee_tag { get; set; }
        public DbSet<employeer> employeers { get; set; }
        public DbSet<job_applicant> job_applicant { get; set; }
        public DbSet<job_applied> job_applied { get; set; }
        public DbSet<job_circular> job_circular { get; set; }
        public DbSet<job_circular_tag> job_circular_tag { get; set; }
        public DbSet<user> users { get; set; }
    }
}
