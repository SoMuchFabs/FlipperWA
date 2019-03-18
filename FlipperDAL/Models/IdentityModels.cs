using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace FlipperDAL.Models
{
    // È possibile aggiungere dati del profilo per l'utente aggiungendo altre proprietà alla classe ApplicationUser. Per altre informazioni, vedere https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public decimal FIDELITY_POINTS { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public DateTime REGISTRATION_DATE { get; set; }
        public DateTime LAST_ACCESS { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Tenere presente che il valore di authenticationType deve corrispondere a quello definito in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Aggiungere qui i reclami utente personalizzati
            return userIdentity;           
        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole,string> store) : base(store)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<FlipperDbContext>()));
            return manager;
        }
    }
    
    //public class FlipperDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public FlipperDbContext()
    //        : base("FlipperDBIdentity")
    //    {
    //    }

    //    public static FlipperDbContext Create()
    //    {
    //        return new FlipperDbContext();
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder); // MUST go first.

    //        modelBuilder.HasDefaultSchema("ITS_GROUP2"); // Use uppercase!     

    //        modelBuilder.Entity<ACTORS>().HasKey(c => c.ID_ACTOR);
    //        modelBuilder.Entity<GENRES>().HasKey(c => c.ID_GENRE);
    //        modelBuilder.Entity<FILM_ACTOR>().HasKey(c => c.ID_FILM_ACTOR);
    //        modelBuilder.Entity<FILM_GENRE>().HasKey(c => c.ID_FILM_GENRE);
    //        modelBuilder.Entity<FILMS>().HasKey(c => c.ID_FILM);
    //        modelBuilder.Entity<GENRES>().HasKey(c => c.ID_GENRE);
    //        modelBuilder.Entity<SCREENINGS>().HasKey(c => c.ID_SCREENING);
    //        modelBuilder.Entity<RESERVATIONS>().HasKey(c => c.ID_RESERVATION);
    //        modelBuilder.Entity<SEATS>().HasKey(c => c.ID_SEAT);
    //        modelBuilder.Entity<THEATERS>().HasKey(c => c.ID_THEATER);

    //        modelBuilder.Entity<ACTORS>().ToTable("ACTORS");
    //        //modelBuilder.Entity<ApplicationUser>().ToTable("ASPNETUSERS");
    //        //modelBuilder.Entity<IdentityRole>().ToTable("ASPNETROLES");
    //        //modelBuilder.Entity<IdentityUserRole>().ToTable("ASPNETUSERROLES");
    //        //modelBuilder.Entity<IdentityUserClaim>().ToTable("ASPNETUSERCLAIMS");
    //        //modelBuilder.Entity<IdentityUserLogin>().ToTable("ASPNETUSERLOGINS");

    //    }
    //}

}