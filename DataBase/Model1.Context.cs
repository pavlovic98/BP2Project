﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BasketballClub> BasketballClubs { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<ClubLeague> ClubLeagues { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PlayerPosition> PlayerPositions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<PlayerCenter> PlayerCenters { get; set; }
    }
}
