//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class l2g_tbl_EmployeeStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public l2g_tbl_EmployeeStatus()
        {
            this.l2g_tbl_UserEmployeementDetails = new HashSet<l2g_tbl_UserEmployeementDetails>();
        }
        [Key]
        public int EmployeeStatusId { get; set; }
        public string EmployeeStatusType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_UserEmployeementDetails> l2g_tbl_UserEmployeementDetails { get; set; }
    }
}
