namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicJournal",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Details = c.String(),
                        Language = c.String(maxLength: 100),
                        ISSN = c.String(maxLength: 100),
                        EISSN = c.String(maxLength: 100),
                        ISIImpactFactor = c.String(),
                        Writer = c.String(maxLength: 200),
                        PdfPath = c.String(),
                        WebsiteURL = c.String(),
                        PublishDate = c.DateTime(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        PublisherProfile_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PublisherProfiles", t => t.PublisherProfile_ID)
                .Index(t => t.PublisherProfile_ID);
            
            AddColumn("dbo.Publishers", "ReTypePassword", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Publishers", "UserName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Publishers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Publishers", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicJournal", "PublisherProfile_ID", "dbo.PublisherProfiles");
            DropIndex("dbo.MedicJournal", new[] { "PublisherProfile_ID" });
            AlterColumn("dbo.Publishers", "Password", c => c.String());
            AlterColumn("dbo.Publishers", "Email", c => c.String());
            AlterColumn("dbo.Publishers", "UserName", c => c.String());
            DropColumn("dbo.Publishers", "ReTypePassword");
            DropTable("dbo.MedicJournal");
        }
    }
}
