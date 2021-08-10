using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppNetCore5.Models.PruebaMuchosMuchos;

namespace WebAppNetCore5.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<RelacionPersona>()
            //    .HasKey(relaciones => new { relaciones.PersonaId, relaciones.FamiliarId });

            //builder.Entity<Familiar>().HasIndex(familiar => new { familiar.PersonaId, familiar.Parentezco }).IsUnique();

            builder.Entity<RelacionPersona>()
                .HasOne(persona => persona.Persona)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RelacionPersona>()
                .HasOne(persona => persona.PersonaFamiliar)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RelacionPersona>()
                .HasIndex(familiar => new { familiar.PersonaId, familiar.PersonaFamiliarId, familiar.Parentezco }).IsUnique();



        }

        public DbSet<Persona> Personas { get; set; }
        //public DbSet<Familiar> Familiares { get; set; }
        public DbSet<RelacionPersona> RelacionsPersonas { get; set; }

    }
}
