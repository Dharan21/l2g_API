﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace l2g.Entities.DataEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Lead2OrderGenerateDbEntities : DbContext
    {
        public Lead2OrderGenerateDbEntities()
            : base("name=Lead2OrderGenerateDbEntities")
        {
        }
    
        public virtual DbSet<l2g_tbl_Brand> l2g_tbl_Brand { get; set; }
        public virtual DbSet<l2g_tbl_Car> l2g_tbl_Car { get; set; }
        public virtual DbSet<l2g_tbl_Contract> l2g_tbl_Contract { get; set; }
        public virtual DbSet<l2g_tbl_EmployeeStatus> l2g_tbl_EmployeeStatus { get; set; }
        public virtual DbSet<l2g_tbl_Fuel> l2g_tbl_Fuel { get; set; }
        public virtual DbSet<l2g_tbl_Gearbox> l2g_tbl_Gearbox { get; set; }
        public virtual DbSet<l2g_tbl_Mileage> l2g_tbl_Mileage { get; set; }
        public virtual DbSet<l2g_tbl_PaybackTime> l2g_tbl_PaybackTime { get; set; }
        public virtual DbSet<l2g_tbl_Quote> l2g_tbl_Quote { get; set; }
        public virtual DbSet<l2g_tbl_User> l2g_tbl_User { get; set; }
        public virtual DbSet<l2g_tbl_UserBankDetails> l2g_tbl_UserBankDetails { get; set; }
        public virtual DbSet<l2g_tbl_UserDetails> l2g_tbl_UserDetails { get; set; }
        public virtual DbSet<l2g_tbl_UserEmployeementDetails> l2g_tbl_UserEmployeementDetails { get; set; }
    }
}
