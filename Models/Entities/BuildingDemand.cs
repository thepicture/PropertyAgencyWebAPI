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
    
    public partial class BuildingDemand
    {
        public int Id { get; set; }
        public Nullable<byte> MinRooms { get; set; }
        public Nullable<byte> MaxRooms { get; set; }
    
        public virtual ApartmentDemand ApartmentDemand { get; set; }
        public virtual Demand Demand { get; set; }
        public virtual HouseDemand HouseDemand { get; set; }
    }
}