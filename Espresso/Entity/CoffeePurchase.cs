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
    
    public partial class CoffeePurchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CoffeePurchase()
        {
            this.CoffeePurchase_Details = new HashSet<CoffeePurchase_Details>();
        }
    
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public bool Paid { get; set; }
        public double Sum { get; set; }
        public Nullable<int> TransactionId { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoffeePurchase_Details> CoffeePurchase_Details { get; set; }
        public virtual Account Account { get; set; }
    }
}
