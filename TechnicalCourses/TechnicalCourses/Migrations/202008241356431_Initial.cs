namespace TechnicalCourses.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        Officeid = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        TutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Officeid)
                .ForeignKey("dbo.Tutors", t => t.TutorId, cascadeDelete: true)
                .Index(t => t.TutorId);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offices", "TutorId", "dbo.Tutors");
            DropIndex("dbo.Offices", new[] { "TutorId" });
            DropTable("dbo.Tutors");
            DropTable("dbo.Offices");
        }
    }
}
