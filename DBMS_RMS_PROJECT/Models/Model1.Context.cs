﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBMS_RMS_PROJECT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_RMSEntities : DbContext
    {
        public DB_RMSEntities()
            : base("name=DB_RMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Passenger> tbl_Passenger { get; set; }
        public virtual DbSet<tbl_Passenger_Detial> tbl_Passenger_Detial { get; set; }
        public virtual DbSet<tbl_Station> tbl_Station { get; set; }
        public virtual DbSet<tbl_Ticket> tbl_Ticket { get; set; }
        public virtual DbSet<tbl_Ticket_Category> tbl_Ticket_Category { get; set; }
        public virtual DbSet<tbl_Train> tbl_Train { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
    }
}