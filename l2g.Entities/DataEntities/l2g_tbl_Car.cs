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

    public partial class l2g_tbl_Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public l2g_tbl_Car()
        {
            this.l2g_tbl_Quote = new HashSet<l2g_tbl_Quote>();
        }
    
        [Key]
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public int FuelId { get; set; }
        public int GearboxId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public decimal CO2Emission { get; set; }
    
        public virtual l2g_tbl_Brand l2g_tbl_Brand { get; set; }
        public virtual l2g_tbl_Fuel l2g_tbl_Fuel { get; set; }
        public virtual l2g_tbl_Gearbox l2g_tbl_Gearbox { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<l2g_tbl_Quote> l2g_tbl_Quote { get; set; }
    }
}
