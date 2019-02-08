namespace FlipperAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ITS_GROUP2.ACTORS",
                c => new
                {
                    ID_ACTOR = c.Decimal(nullable: false, precision: 38, scale: 0),
                    NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                    SURNAME = c.String(nullable: false, maxLength: 100, unicode: false),
                })
                .PrimaryKey(t => t.ID_ACTOR);

            CreateTable(
                "ITS_GROUP2.FILM_ACTOR",
                c => new
                {
                    ID_FILM_ACTOR = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_FILM = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_ACTOR = c.Decimal(nullable: false, precision: 38, scale: 0),
                })
                .PrimaryKey(t => t.ID_FILM_ACTOR)
                .ForeignKey("ITS_GROUP2.FILMS", t => t.ID_FILM)
                .ForeignKey("ITS_GROUP2.ACTORS", t => t.ID_ACTOR)
                .Index(t => t.ID_FILM)
                .Index(t => t.ID_ACTOR);

            CreateTable(
                "ITS_GROUP2.FILMS",
                c => new
                {
                    ID_FILM = c.Decimal(nullable: false, precision: 38, scale: 0),
                    NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                    RELEASE_DATE = c.DateTime(nullable: false),
                    PLOT = c.String(maxLength: 500, unicode: false),
                })
                .PrimaryKey(t => t.ID_FILM);

            CreateTable(
                "ITS_GROUP2.FILM_GENRE",
                c => new
                {
                    ID_FILM_GENRE = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_FILM = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_GENRE = c.Decimal(nullable: false, precision: 38, scale: 0),
                })
                .PrimaryKey(t => t.ID_FILM_GENRE)
                .ForeignKey("ITS_GROUP2.GENRES", t => t.ID_GENRE)
                .ForeignKey("ITS_GROUP2.FILMS", t => t.ID_FILM)
                .Index(t => t.ID_FILM)
                .Index(t => t.ID_GENRE);

            CreateTable(
                "ITS_GROUP2.GENRES",
                c => new
                {
                    ID_GENRE = c.Decimal(nullable: false, precision: 38, scale: 0),
                    NAME = c.String(maxLength: 100, unicode: false),
                    DESCRIPTION = c.String(maxLength: 500, unicode: false),
                })
                .PrimaryKey(t => t.ID_GENRE);

            CreateTable(
                "ITS_GROUP2.SCREENINGS",
                c => new
                {
                    ID_SCREENING = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_FILM = c.Decimal(nullable: false, precision: 38, scale: 0),
                    SCREENING_DATE = c.DateTime(nullable: false),
                    PRICE = c.Decimal(precision: 2, scale: 2),
                    REDUCTED_PRICE = c.Decimal(precision: 2, scale: 2),
                    ID_THEATER = c.Decimal(nullable: false, precision: 38, scale: 0),
                })
                .PrimaryKey(t => t.ID_SCREENING)
                .ForeignKey("ITS_GROUP2.THEATERS", t => t.ID_THEATER)
                .ForeignKey("ITS_GROUP2.FILMS", t => t.ID_FILM)
                .Index(t => t.ID_FILM)
                .Index(t => t.ID_THEATER);

            CreateTable(
                "ITS_GROUP2.RESERVATIONS",
                c => new
                {
                    ID_RESERVATION = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_SCREENING = c.Decimal(nullable: false, precision: 38, scale: 0),
                    RESERVATION_DATE = c.DateTime(),
                    ID_SEAT = c.Decimal(nullable: false, precision: 38, scale: 0),
                    ID_USER = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.ID_RESERVATION)
                .ForeignKey("ITS_GROUP2.ApplicationUsers", t => t.ID_USER)
                .ForeignKey("ITS_GROUP2.SEATS", t => t.ID_SEAT)
                .ForeignKey("ITS_GROUP2.SCREENINGS", t => t.ID_SCREENING)
                .Index(t => t.ID_SCREENING)
                .Index(t => t.ID_SEAT)
                .Index(t => t.ID_USER);

            //CreateTable(
            //    "ITS_GROUP2.ASPNETUSERS",
            //    c => new
            //    {
            //        ID = c.String(nullable: false, maxLength: 128),
            //        EMAIL = c.String(maxLength: 256),
            //        EMAILCONFIRMED = c.Decimal(nullable: false, precision: 1, scale: 0),
            //        PASSWORDHASH = c.String(maxLength: 256),
            //        SECURITYSTAMP = c.String(maxLength: 256),
            //        PHONENUMBER = c.String(maxLength: 256),
            //        PHONENUMBERCONFIRMED = c.Decimal(nullable: false, precision: 1, scale: 0),
            //        TWOFACTORENABLED = c.Decimal(nullable: false, precision: 1, scale: 0),
            //        LOCKOUTENDDATEUTC = c.DateTime(),
            //        LOCKOUTENABLED = c.Decimal(nullable: false, precision: 1, scale: 0),
            //        ACCESSFAILEDCOUNT = c.Decimal(nullable: false, precision: 10, scale: 0),
            //        USERNAME = c.String(nullable: false, maxLength: 256),
            //        NAME = c.String(maxLength: 100, unicode: false),
            //        SURNAME = c.String(maxLength: 100, unicode: false),
            //        REGISTRATION_DATE = c.DateTime(),
            //        LAST_ACCESS = c.DateTime(),
            //        FIDELITY_POINTS = c.Decimal(precision: 38, scale: 0),
            //        IS_ACTIVE = c.Decimal(precision: 1, scale: 0),
            //    })
            //    .PrimaryKey(t => t.ID);

            CreateTable(
                "ITS_GROUP2.SEATS",
                c => new
                {
                    ID_SEAT = c.Decimal(nullable: false, precision: 38, scale: 0),
                    CODE = c.String(nullable: false, maxLength: 2, unicode: false),
                    ID_THEATER = c.Decimal(nullable: false, precision: 38, scale: 0),
                })
                .PrimaryKey(t => t.ID_SEAT)
                .ForeignKey("ITS_GROUP2.THEATERS", t => t.ID_THEATER)
                .Index(t => t.ID_THEATER);

            CreateTable(
                "ITS_GROUP2.THEATERS",
                c => new
                {
                    ID_THEATER = c.Decimal(nullable: false, precision: 38, scale: 0),
                    NAME = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.ID_THEATER);

            //CreateTable(
            //    "ITS_GROUP2.ASPNETROLES",
            //    c => new
            //    {
            //        ID = c.String(nullable: false, maxLength: 128),
            //        NAME = c.String(nullable: false, maxLength: 256),
            //    })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "ITS_GROUP2.ASPNETUSERCLAIMS",
            //    c => new
            //    {
            //        ID = c.Decimal(nullable: false, precision: 10, scale: 0),
            //        USERID = c.String(nullable: false, maxLength: 128),
            //        CLAIMTYPE = c.String(maxLength: 256),
            //        CLAIMVALUE = c.String(maxLength: 256),
            //    })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "ITS_GROUP2.ASPNETUSERROLES",
            //    c => new
            //    {
            //        USERID = c.String(nullable: false, maxLength: 128),
            //        ROLEID = c.String(nullable: false, maxLength: 128),
            //    })
            //    .PrimaryKey(t => new { t.USERID, t.ROLEID });

            CreateTable(
                "ITS_GROUP2.__MigrationHistory",
                c => new
                {
                    MigrationId = c.String(nullable: false, maxLength: 150),
                    ContextKey = c.String(nullable: false, maxLength: 300),
                    Model = c.Binary(nullable: false),
                    ProductVersion = c.String(nullable: false, maxLength: 32),
                })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });

            CreateTable(
                "ITS_GROUP2.FIDELITY_BONUS",
                c => new
                {
                    ID_FIDELITY_BONUS = c.Decimal(nullable: false, precision: 38, scale: 0),
                    NAME = c.String(nullable: false, maxLength: 100, unicode: false),
                    DESCRIPTION = c.String(maxLength: 500, unicode: false),
                    COST = c.Decimal(nullable: false, precision: 38, scale: 0),
                })
                .PrimaryKey(t => t.ID_FIDELITY_BONUS);

            CreateTable(
                "ITS_GROUP2.IDENTITYROLES",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ITS_GROUP2.IDENTITYUSERROLES",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("ITS_GROUP2.IDENTITYROLES", t => t.IdentityRole_Id)
                .ForeignKey("ITS_GROUP2.APPLICATIONUSERS", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "ITS_GROUP2.APPLICATIONUSERS",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FIDELITY_POINTS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NAME = c.String(),
                        SURNAME = c.String(),
                        REGISTRATION_DATE = c.DateTime(nullable: false),
                        LAST_ACCESS = c.DateTime(nullable: false),
                        IS_ACTIVE = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Email = c.String(),
                        EmailConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        TwoFactorEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        AccessFailedCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ITS_GROUP2.IDENTITYUSERCLAIMS",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ITS_GROUP2.APPLICATIONUSERS", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "ITS_GROUP2.IDENTITYUSERLOGINS",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("ITS_GROUP2.APPLICATIONUSERS", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);

            CreateTable(
                "ITS_GROUP2.VW_FILM_CATALOG",
                c => new
                {
                    NOME = c.String(nullable: false, maxLength: 100, unicode: false),
                    RILASCIATO = c.DateTime(nullable: false),
                    TRAMA = c.String(maxLength: 500, unicode: false),
                    ATTORI = c.String(maxLength: 4000, unicode: false),
                    CATEGORIA = c.String(maxLength: 4000, unicode: false),
                })
                .PrimaryKey(t => new { t.NOME, t.RILASCIATO });

        }
        
        public override void Down()
        {
            DropForeignKey("ITS_GROUP2.IDENTITYUSERROLES", "ApplicationUser_Id", "ITS_GROUP2.APPLICATIONUSERS");
            DropForeignKey("ITS_GROUP2.IDENTITYUSERLOGINS", "ApplicationUser_Id", "ITS_GROUP2.APPLICATIONUSERS");
            DropForeignKey("ITS_GROUP2.IDENTITYUSERCLAIMS", "ApplicationUser_Id", "ITS_GROUP2.APPLICATIONUSERS");
            DropForeignKey("ITS_GROUP2.IDENTITYUSERROLES", "IdentityRole_Id", "ITS_GROUP2.IDENTITYROLES");
            DropForeignKey("ITS_GROUP2.FILM_ACTOR", "ID_ACTOR", "ITS_GROUP2.ACTORS");
            DropForeignKey("ITS_GROUP2.SCREENINGS", "ID_FILM", "ITS_GROUP2.FILMS");
            DropForeignKey("ITS_GROUP2.RESERVATIONS", "ID_SCREENING", "ITS_GROUP2.SCREENINGS");
            DropForeignKey("ITS_GROUP2.SEATS", "ID_THEATER", "ITS_GROUP2.THEATERS");
            DropForeignKey("ITS_GROUP2.SCREENINGS", "ID_THEATER", "ITS_GROUP2.THEATERS");
            DropForeignKey("ITS_GROUP2.RESERVATIONS", "ID_SEAT", "ITS_GROUP2.SEATS");
            DropForeignKey("ITS_GROUP2.RESERVATIONS", "ID_USER", "ITS_GROUP2.ApplicationUsers");
            DropForeignKey("ITS_GROUP2.FILM_GENRE", "ID_FILM", "ITS_GROUP2.FILMS");
            DropForeignKey("ITS_GROUP2.FILM_GENRE", "ID_GENRE", "ITS_GROUP2.GENRES");
            DropForeignKey("ITS_GROUP2.FILM_ACTOR", "ID_FILM", "ITS_GROUP2.FILMS");
            DropIndex("ITS_GROUP2.IDENTITYUSERLOGINS", new[] { "ApplicationUser_Id" });
            DropIndex("ITS_GROUP2.IDENTITYUSERCLAIMS", new[] { "ApplicationUser_Id" });
            DropIndex("ITS_GROUP2.IDENTITYUSERROLES", new[] { "ApplicationUser_Id" });
            DropIndex("ITS_GROUP2.IDENTITYUSERROLES", new[] { "IdentityRole_Id" });
            DropIndex("ITS_GROUP2.SEATS", new[] { "ID_THEATER" });
            DropIndex("ITS_GROUP2.RESERVATIONS", new[] { "ID_USER" });
            DropIndex("ITS_GROUP2.RESERVATIONS", new[] { "ID_SEAT" });
            DropIndex("ITS_GROUP2.RESERVATIONS", new[] { "ID_SCREENING" });
            DropIndex("ITS_GROUP2.SCREENINGS", new[] { "ID_THEATER" });
            DropIndex("ITS_GROUP2.SCREENINGS", new[] { "ID_FILM" });
            DropIndex("ITS_GROUP2.FILM_GENRE", new[] { "ID_GENRE" });
            DropIndex("ITS_GROUP2.FILM_GENRE", new[] { "ID_FILM" });
            DropIndex("ITS_GROUP2.FILM_ACTOR", new[] { "ID_ACTOR" });
            DropIndex("ITS_GROUP2.FILM_ACTOR", new[] { "ID_FILM" });
            DropTable("ITS_GROUP2.VW_FILM_CATALOG");
            DropTable("ITS_GROUP2.IDENTITYUSERLOGINS");
            DropTable("ITS_GROUP2.IDENTITYUSERCLAIMS");
            DropTable("ITS_GROUP2.APPLICATIONUSERS");
            DropTable("ITS_GROUP2.IDENTITYUSERROLES");
            DropTable("ITS_GROUP2.IDENTITYROLES");
            DropTable("ITS_GROUP2.FIDELITY_BONUS");
            DropTable("ITS_GROUP2.__MigrationHistory");
            //DropTable("ITS_GROUP2.ASPNETUSERROLES");
            //DropTable("ITS_GROUP2.ASPNETUSERCLAIMS");
            //DropTable("ITS_GROUP2.ASPNETROLES");
            DropTable("ITS_GROUP2.THEATERS");
            DropTable("ITS_GROUP2.SEATS");
            //DropTable("ITS_GROUP2.ASPNETUSERS");
            DropTable("ITS_GROUP2.RESERVATIONS");
            DropTable("ITS_GROUP2.SCREENINGS");
            DropTable("ITS_GROUP2.GENRES");
            DropTable("ITS_GROUP2.FILM_GENRE");
            DropTable("ITS_GROUP2.FILMS");
            DropTable("ITS_GROUP2.FILM_ACTOR");
            DropTable("ITS_GROUP2.ACTORS");
        }
    }
}
