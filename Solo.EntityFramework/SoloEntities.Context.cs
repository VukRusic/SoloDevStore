﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solo.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SoloEntities : DbContext
    {
        public SoloEntities()
            : base("name=SoloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Developer> Developers { get; set; }
        public DbSet<EvidencijaProdaje> EvidencijaProdajes { get; set; }
        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Nalog> Nalogs { get; set; }
        public DbSet<Racun> Racuns { get; set; }
        public DbSet<Radnik> Radniks { get; set; }
        public DbSet<Recenzija> Recenzijas { get; set; }
        public DbSet<RegistrovanProizvod> RegistrovanProizvods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
