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
    
    public partial class Mix_Details
    {
        public int Id { get; set; }
        public int Ratio { get; set; }
    
        public virtual Mix Mix { get; set; }
        public virtual CoffeeSort CoffeeSort { get; set; }
    }
}
