//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Espresso.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipient()
        {
            this.Active = true;
            this.CoffeeSales = new HashSet<CoffeeSale>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CoffeeSale> CoffeeSales { get; set; }
    }
}
