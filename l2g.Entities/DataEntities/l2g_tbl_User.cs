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

    public partial class l2g_tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public l2g_tbl_User()
        {
            this.l2g_tbl_Quote = new HashSet<l2g_tbl_Quote>();
            this.l2g_tbl_UserBankDetails = new HashSet<l2g_tbl_UserBankDetails>();
            this.l2g_tbl_UserDetails = new HashSet<l2g_tbl_UserDetails>();
            this.l2g_tbl_UserEmployeementDetails = new HashSet<l2g_tbl_UserEmployeementDetails>();
        }
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_Quote> l2g_tbl_Quote { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_UserBankDetails> l2g_tbl_UserBankDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_UserDetails> l2g_tbl_UserDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_UserEmployeementDetails> l2g_tbl_UserEmployeementDetails { get; set; }
    }
}
