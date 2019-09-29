namespace AadhaarFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    /// <summary>
    /// Initial script database creation
    /// </summary>
    public partial class Initial : DbMigration
    {
        /// <summary>
        /// Create the tables on database
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.CountryZones",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        Token = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Eyes",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Iris = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FingerPrints",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Finger = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        HouseBuildingApartment = c.String(),
                        StreetRoadLane = c.String(),
                        Landmark = c.String(),
                        AreaLocalitySector = c.String(),
                        VillageTownCity = c.String(),
                        CountryArea = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IdGender = c.Long(nullable: false),
                        IdReligion = c.Long(nullable: false),
                        IdState = c.Long(nullable: false),
                        IdEnroller = c.Long(nullable: false),
                        IdLanguage = c.Long(nullable: false),
                        IsDesceased = c.Boolean(nullable: false),
                        IsDuplicated = c.Boolean(nullable: false),
                        IdPhotography = c.Long(),
                        IdIrisLeftEye = c.Long(),
                        IdIrisRightEye = c.Long(),
                        IdFingerPrintLeftHandThumb = c.Long(),
                        IdFingerPrintLeftHandIndex = c.Long(),
                        IdFingerPrintLeftHandMiddle = c.Long(),
                        IdFingerPrintLeftHandRing = c.Long(),
                        IdFingerPrintLeftHandPinky = c.Long(),
                        IdFingerPrintRightHandThumb = c.Long(),
                        IdFingerPrintRightHandIndex = c.Long(),
                        IdFingerPrintRightHandMiddle = c.Long(),
                        IdFingerPrintRightHandRing = c.Long(),
                        IdFingerPrintRightHandPinky = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enrollers", t => t.IdEnroller)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintLeftHandIndex)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintLeftHandMiddle)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintLeftHandPinky)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintLeftHandRing)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintLeftHandThumb)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintRightHandIndex)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintRightHandMiddle)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintRightHandPinky)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintRightHandRing)
                .ForeignKey("dbo.FingerPrints", t => t.IdFingerPrintRightHandThumb)
                .ForeignKey("dbo.Genders", t => t.IdGender)
                .ForeignKey("dbo.Eyes", t => t.IdIrisLeftEye)
                .ForeignKey("dbo.Eyes", t => t.IdIrisRightEye)
                .ForeignKey("dbo.Languages", t => t.IdLanguage)
                .ForeignKey("dbo.Photographies", t => t.IdPhotography)
                .ForeignKey("dbo.Religions", t => t.IdReligion)
                .ForeignKey("dbo.States", t => t.IdState)
                .Index(t => t.IdGender)
                .Index(t => t.IdReligion)
                .Index(t => t.IdState)
                .Index(t => t.IdEnroller)
                .Index(t => t.IdLanguage)
                .Index(t => t.IdPhotography)
                .Index(t => t.IdIrisLeftEye)
                .Index(t => t.IdIrisRightEye)
                .Index(t => t.IdFingerPrintLeftHandThumb)
                .Index(t => t.IdFingerPrintLeftHandIndex)
                .Index(t => t.IdFingerPrintLeftHandMiddle)
                .Index(t => t.IdFingerPrintLeftHandRing)
                .Index(t => t.IdFingerPrintLeftHandPinky)
                .Index(t => t.IdFingerPrintRightHandThumb)
                .Index(t => t.IdFingerPrintRightHandIndex)
                .Index(t => t.IdFingerPrintRightHandMiddle)
                .Index(t => t.IdFingerPrintRightHandRing)
                .Index(t => t.IdFingerPrintRightHandPinky);
            
            CreateTable(
                "dbo.Photographies",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Capital = c.String(),
                        Area = c.Int(nullable: false),
                        Population = c.Int(nullable: false),
                        Latitud = c.Decimal(nullable: false, precision: 9, scale: 6),
                        Longitud = c.Decimal(nullable: false, precision: 9, scale: 6),
                        IdOfficialLanguage = c.Long(nullable: false),
                        IdCountryZone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountryZones", t => t.IdCountryZone)
                .ForeignKey("dbo.Languages", t => t.IdOfficialLanguage)
                .Index(t => t.IdOfficialLanguage)
                .Index(t => t.IdCountryZone);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        UserName = c.String(maxLength: 100),
                        Password = c.String(),
                        FirstName = c.String(maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.vwPopulation",
            //    c => new
            //        {
            //            Id = c.Long(nullable: false, identity: true),
            //            FirstName = c.String(),
            //            MiddleName = c.String(),
            //            BirthDate = c.DateTime(nullable: false),
            //            Age = c.Int(nullable: false),
            //            IsDesceased = c.Boolean(nullable: false),
            //            IsDuplicated = c.Boolean(nullable: false),
            //            CreatedDate = c.DateTime(nullable: false),
            //            CreatedBy = c.String(),
            //            ModifyDate = c.DateTime(),
            //            ModifyBy = c.String(),
            //            CorrectionIndex = c.Int(nullable: false),
            //            IsHandicapped = c.Boolean(nullable: false),
            //            StateName = c.String(),
            //            Area = c.Int(nullable: false),
            //            Latitud = c.Decimal(nullable: false, precision: 9, scale: 6),
            //            Longitud = c.Decimal(nullable: false, precision: 9, scale: 6),
            //            Population = c.Int(nullable: false),
            //            CountryZoneName = c.String(),
            //            GenderName = c.String(),
            //            ReligionName = c.String(),
            //            EnrollerName = c.String(),
            //            EnrollerIsEnabled = c.Boolean(nullable: false),
            //            LanguageName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRols",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Rol_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Rol_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Rols", t => t.Rol_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Rol_Id);
            
        }
        /// <summary>
        /// Drops the tables in case the initialization goes wrong
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.UserRols", "Rol_Id", "dbo.Rols");
            DropForeignKey("dbo.UserRols", "User_Id", "dbo.Users");
            DropForeignKey("dbo.People", "IdState", "dbo.States");
            DropForeignKey("dbo.States", "IdOfficialLanguage", "dbo.Languages");
            DropForeignKey("dbo.States", "IdCountryZone", "dbo.CountryZones");
            DropForeignKey("dbo.People", "IdReligion", "dbo.Religions");
            DropForeignKey("dbo.People", "IdPhotography", "dbo.Photographies");
            DropForeignKey("dbo.People", "IdLanguage", "dbo.Languages");
            DropForeignKey("dbo.People", "IdIrisRightEye", "dbo.Eyes");
            DropForeignKey("dbo.People", "IdIrisLeftEye", "dbo.Eyes");
            DropForeignKey("dbo.People", "IdGender", "dbo.Genders");
            DropForeignKey("dbo.People", "IdFingerPrintRightHandThumb", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintRightHandRing", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintRightHandPinky", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintRightHandMiddle", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintRightHandIndex", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintLeftHandThumb", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintLeftHandRing", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintLeftHandPinky", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintLeftHandMiddle", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdFingerPrintLeftHandIndex", "dbo.FingerPrints");
            DropForeignKey("dbo.People", "IdEnroller", "dbo.Enrollers");
            DropIndex("dbo.UserRols", new[] { "Rol_Id" });
            DropIndex("dbo.UserRols", new[] { "User_Id" });
            DropIndex("dbo.States", new[] { "IdCountryZone" });
            DropIndex("dbo.States", new[] { "IdOfficialLanguage" });
            DropIndex("dbo.People", new[] { "IdFingerPrintRightHandPinky" });
            DropIndex("dbo.People", new[] { "IdFingerPrintRightHandRing" });
            DropIndex("dbo.People", new[] { "IdFingerPrintRightHandMiddle" });
            DropIndex("dbo.People", new[] { "IdFingerPrintRightHandIndex" });
            DropIndex("dbo.People", new[] { "IdFingerPrintRightHandThumb" });
            DropIndex("dbo.People", new[] { "IdFingerPrintLeftHandPinky" });
            DropIndex("dbo.People", new[] { "IdFingerPrintLeftHandRing" });
            DropIndex("dbo.People", new[] { "IdFingerPrintLeftHandMiddle" });
            DropIndex("dbo.People", new[] { "IdFingerPrintLeftHandIndex" });
            DropIndex("dbo.People", new[] { "IdFingerPrintLeftHandThumb" });
            DropIndex("dbo.People", new[] { "IdIrisRightEye" });
            DropIndex("dbo.People", new[] { "IdIrisLeftEye" });
            DropIndex("dbo.People", new[] { "IdPhotography" });
            DropIndex("dbo.People", new[] { "IdLanguage" });
            DropIndex("dbo.People", new[] { "IdEnroller" });
            DropIndex("dbo.People", new[] { "IdState" });
            DropIndex("dbo.People", new[] { "IdReligion" });
            DropIndex("dbo.People", new[] { "IdGender" });
            DropTable("dbo.UserRols");
            
            DropTable("dbo.Users");
            DropTable("dbo.Rols");
            DropTable("dbo.States");
            DropTable("dbo.Religions");
            DropTable("dbo.Photographies");
            DropTable("dbo.People");
            DropTable("dbo.Languages");
            DropTable("dbo.Genders");
            DropTable("dbo.FingerPrints");
            DropTable("dbo.Eyes");
            DropTable("dbo.Enrollers");
            DropTable("dbo.CountryZones");
        }
    }
}
