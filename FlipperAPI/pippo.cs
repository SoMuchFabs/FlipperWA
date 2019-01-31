namespace FlipperAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using FlipperAPI.Models;

    public partial class ciao : IdentityDbContext
    {
        public ciao()
            : base("name=FlipperDB")
        {
        }

        public static ciao Create()
        {
            return new ciao();
        }

        public virtual DbSet<ACTORS> ACTORS { get; set; }
        public virtual DbSet<CUSTOMERS> CUSTOMERS { get; set; }
        public virtual DbSet<FIDELITY_BONUS> FIDELITY_BONUS { get; set; }
        public virtual DbSet<FILM_ACTOR> FILM_ACTOR { get; set; }
        public virtual DbSet<FILM_GENRE> FILM_GENRE { get; set; }
        public virtual DbSet<FILMS> FILMS { get; set; }
        public virtual DbSet<GENRES> GENRES { get; set; }
        public virtual DbSet<RESERVATIONS> RESERVATIONS { get; set; }
        public virtual DbSet<SCREENINGS> SCREENINGS { get; set; }
        public virtual DbSet<SEATS> SEATS { get; set; }
        public virtual DbSet<THEATERS> THEATERS { get; set; }
        public virtual DbSet<VW_FILM_CATALOG> VW_FILM_CATALOG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // MUST go first.

            modelBuilder.HasDefaultSchema("ITS_GROUP2"); // Use uppercase!
            modelBuilder.Entity<ACTORS>()
                .Property(e => e.ID_ACTOR)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ACTORS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ACTORS>()
                .Property(e => e.SURNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ACTORS>()
                .HasMany(e => e.FILM_ACTOR)
                .WithRequired(e => e.ACTORS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.ID_CUSTOMER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.SURNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.FIDELITY_POINTS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<CUSTOMERS>()
                .HasMany(e => e.RESERVATIONS)
                .WithRequired(e => e.CUSTOMERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FIDELITY_BONUS>()
                .Property(e => e.ID_FIDELITY_BONUS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FIDELITY_BONUS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FIDELITY_BONUS>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<FIDELITY_BONUS>()
                .Property(e => e.COST)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_ACTOR>()
                .Property(e => e.ID_FILM_ACTOR)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_ACTOR>()
                .Property(e => e.ID_FILM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_ACTOR>()
                .Property(e => e.ID_ACTOR)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_GENRE>()
                .Property(e => e.ID_FILM_GENRE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_GENRE>()
                .Property(e => e.ID_FILM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILM_GENRE>()
                .Property(e => e.ID_GENRE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.ID_FILM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .Property(e => e.PLOT)
                .IsUnicode(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.FILM_ACTOR)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.FILM_GENRE)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FILMS>()
                .HasMany(e => e.SCREENINGS)
                .WithRequired(e => e.FILMS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENRES>()
                .Property(e => e.ID_GENRE)
                .HasPrecision(38, 0);

            modelBuilder.Entity<GENRES>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<GENRES>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<GENRES>()
                .HasMany(e => e.FILM_GENRE)
                .WithRequired(e => e.GENRES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RESERVATIONS>()
                .Property(e => e.ID_RESERVATION)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RESERVATIONS>()
                .Property(e => e.ID_CUSTOMER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RESERVATIONS>()
                .Property(e => e.ID_SCREENING)
                .HasPrecision(38, 0);

            modelBuilder.Entity<RESERVATIONS>()
                .Property(e => e.ID_SEAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SCREENINGS>()
                .Property(e => e.ID_SCREENING)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SCREENINGS>()
                .Property(e => e.ID_FILM)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SCREENINGS>()
                .Property(e => e.PRICE)
                .HasPrecision(2, 2);

            modelBuilder.Entity<SCREENINGS>()
                .Property(e => e.REDUCTED_PRICE)
                .HasPrecision(2, 2);

            modelBuilder.Entity<SCREENINGS>()
                .HasMany(e => e.RESERVATIONS)
                .WithRequired(e => e.SCREENINGS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SEATS>()
                .Property(e => e.ID_SEAT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SEATS>()
                .Property(e => e.CODE)
                .IsUnicode(false);

            modelBuilder.Entity<SEATS>()
                .Property(e => e.ID_THEATER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SEATS>()
                .HasMany(e => e.RESERVATIONS)
                .WithRequired(e => e.SEATS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THEATERS>()
                .Property(e => e.ID_THEATER)
                .HasPrecision(38, 0);

            modelBuilder.Entity<THEATERS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<THEATERS>()
                .HasMany(e => e.SEATS)
                .WithRequired(e => e.THEATERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VW_FILM_CATALOG>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<VW_FILM_CATALOG>()
                .Property(e => e.TRAMA)
                .IsUnicode(false);

            modelBuilder.Entity<VW_FILM_CATALOG>()
                .Property(e => e.ATTORI)
                .IsUnicode(false);

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUserLogins");
        }


    }
}
