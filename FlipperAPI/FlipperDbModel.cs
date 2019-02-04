namespace FlipperAPI
{
    using FlipperAPI.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public partial class FlipperDbModel : IdentityDbContext<ApplicationUser>
    {
        public FlipperDbModel()
            : base("name=FlipperDbModel")
        {
        }

        public static FlipperDbModel Create()
        {
            return new FlipperDbModel();
        }
        #region ROBAINUTILE

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ACTORS> ACTORS { get; set; }
        public virtual DbSet<ASPNETROLES> ASPNETROLES { get; set; }
        public virtual DbSet<ASPNETUSERCLAIMS> ASPNETUSERCLAIMS { get; set; }
        public virtual DbSet<ASPNETUSERROLES> ASPNETUSERROLES { get; set; }
        public virtual DbSet<ASPNETUSERS> ASPNETUSERS { get; set; }
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
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // MUST go first.

            modelBuilder.HasDefaultSchema("ITS_GROUP2"); // Use uppercase!

            modelBuilder
            .Properties()
            .Where(p => p.PropertyType == typeof(string) &&
                    p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0)
            .Configure(p => p.HasMaxLength(2000));

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

            modelBuilder.Entity<ASPNETUSERS>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASPNETUSERS>()
                .Property(e => e.SURNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ASPNETUSERS>()
                .Property(e => e.FIDELITY_POINTS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ASPNETUSERS>()
                .HasMany(e => e.RESERVATIONS)
                .WithRequired(e => e.ASPNETUSERS)
                .HasForeignKey(e => e.ID_USER)
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
                .Property(e => e.ID_THEATER)
                .HasPrecision(38, 0);

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
                .HasMany(e => e.SCREENINGS)
                .WithRequired(e => e.THEATERS)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<VW_FILM_CATALOG>()
                .Property(e => e.CATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<IdentityRole>().ToTable("IDENTITYROLES");
            modelBuilder.Entity<ApplicationUser>().ToTable("APPLICATIONUSERS");
            modelBuilder.Entity<IdentityUserRole>().ToTable("IDENTITYUSERROLES");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("IDENTITYUSERLOGINS");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("IDENTITYUSERCLAIMS");

            //modelBuilder.Entity<IdentityUserRole>().HasKey(x => x.UserId);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey(x => x.UserId);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(x => x.RoleId);

        }
    }
}
