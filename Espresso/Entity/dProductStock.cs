//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class dProductStock
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dProductStock()
        {
            this.Quantity = 0D;
            this.Cost = 0D;
        }
    
        public int Id { get; set; }
        public double Quantity { get; set; }
        public double Cost { get; set; }
    
        public virtual Product Product { get; set; }
    }
}