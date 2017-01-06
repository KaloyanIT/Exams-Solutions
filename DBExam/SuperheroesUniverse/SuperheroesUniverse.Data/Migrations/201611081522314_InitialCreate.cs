namespace SuperheroesUniverse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        PlanetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planets", t => t.PlanetId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.PlanetId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Fraction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fractions", t => t.Fraction_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Fraction_Id);
            
            CreateTable(
                "dbo.Fractions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 35),
                        Aligment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        SecretIndentity = c.String(nullable: false, maxLength: 20),
                        CityId = c.Int(nullable: false),
                        Aligment = c.Int(nullable: false),
                        Story = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.SecretIndentity, unique: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Powers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 35),
                        Superhero_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Superheroes", t => t.Superhero_Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Superhero_Id);
            
            CreateTable(
                "dbo.SuperheroFractions",
                c => new
                    {
                        Superhero_Id = c.Int(nullable: false),
                        Fraction_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Superhero_Id, t.Fraction_Id })
                .ForeignKey("dbo.Superheroes", t => t.Superhero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fractions", t => t.Fraction_Id, cascadeDelete: true)
                .Index(t => t.Superhero_Id)
                .Index(t => t.Fraction_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planets", "Fraction_Id", "dbo.Fractions");
            DropForeignKey("dbo.Powers", "Superhero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.SuperheroFractions", "Fraction_Id", "dbo.Fractions");
            DropForeignKey("dbo.SuperheroFractions", "Superhero_Id", "dbo.Superheroes");
            DropForeignKey("dbo.Superheroes", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "PlanetId", "dbo.Planets");
            DropIndex("dbo.SuperheroFractions", new[] { "Fraction_Id" });
            DropIndex("dbo.SuperheroFractions", new[] { "Superhero_Id" });
            DropIndex("dbo.Powers", new[] { "Superhero_Id" });
            DropIndex("dbo.Powers", new[] { "Name" });
            DropIndex("dbo.Superheroes", new[] { "CityId" });
            DropIndex("dbo.Superheroes", new[] { "SecretIndentity" });
            DropIndex("dbo.Fractions", new[] { "Name" });
            DropIndex("dbo.Planets", new[] { "Fraction_Id" });
            DropIndex("dbo.Planets", new[] { "Name" });
            DropIndex("dbo.Countries", new[] { "PlanetId" });
            DropIndex("dbo.Countries", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropTable("dbo.SuperheroFractions");
            DropTable("dbo.Powers");
            DropTable("dbo.Superheroes");
            DropTable("dbo.Fractions");
            DropTable("dbo.Planets");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
