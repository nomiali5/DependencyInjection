namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublisherProfiles",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publishers", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublisherProfiles", "ID", "dbo.Publishers");
            DropIndex("dbo.PublisherProfiles", new[] { "ID" });
            DropTable("dbo.Publishers");
            DropTable("dbo.PublisherProfiles");
        }
    }
}
