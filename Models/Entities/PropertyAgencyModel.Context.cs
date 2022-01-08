﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PropertyAgencyBaseEntities : DbContext
    {
        public PropertyAgencyBaseEntities()
            : base("name=PropertyAgencyBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<ApartmentDemand> ApartmentDemand { get; set; }
        public virtual DbSet<BuildingDemand> BuildingDemand { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Demand> Demand { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DistrictPolygon> DistrictPolygon { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseDemand> HouseDemand { get; set; }
        public virtual DbSet<Land> Land { get; set; }
        public virtual DbSet<LandDemand> LandDemand { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyAddress> PropertyAddress { get; set; }
        public virtual DbSet<RealEstateType> RealEstateType { get; set; }
    }
}