namespace ExamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Population = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Population = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Streets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        DeletedDate = c.DateTime(),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Streets", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Streets", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropTable("dbo.Streets");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
