//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyAgencyWebAPI.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Nullable<int> TotalFloors { get; set; }
        public Nullable<int> RoomsCount { get; set; }
        public Nullable<decimal> TotalArea { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
