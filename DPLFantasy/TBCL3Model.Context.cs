﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DPLFantasy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TBCL3FantasyLeagueEntities : DbContext
    {
        public TBCL3FantasyLeagueEntities()
            : base("name=TBCL3FantasyLeagueEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DreamTeamPlayer> DreamTeamPlayers { get; set; }
        public virtual DbSet<DreamTeam> DreamTeams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
    }
}
