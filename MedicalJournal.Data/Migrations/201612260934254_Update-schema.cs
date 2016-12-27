namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateschema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicJournal", "PublisherProfile_ID", "dbo.PublisherProfiles");
            DropForeignKey("dbo.MedicJournal", "JournalType_ID", "dbo.JournalTypes");
            DropIndex("dbo.MedicJournal", new[] { "JournalType_ID" });
            DropIndex("dbo.MedicJournal", new[] { "PublisherProfile_ID" });
            RenameColumn(table: "dbo.MedicJournal", name: "JournalType_ID", newName: "JournalTypeID");
            AlterColumn("dbo.MedicJournal", "JournalTypeID", c => c.Long(nullable: false));
            CreateIndex("dbo.MedicJournal", "JournalTypeID");
            AddForeignKey("dbo.MedicJournal", "JournalTypeID", "dbo.JournalTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.MedicJournal", "PublisherProfile_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicJournal", "PublisherProfile_ID", c => c.Long());
            DropForeignKey("dbo.MedicJournal", "JournalTypeID", "dbo.JournalTypes");
            DropIndex("dbo.MedicJournal", new[] { "JournalTypeID" });
            AlterColumn("dbo.MedicJournal", "JournalTypeID", c => c.Long());
            RenameColumn(table: "dbo.MedicJournal", name: "JournalTypeID", newName: "JournalType_ID");
            CreateIndex("dbo.MedicJournal", "PublisherProfile_ID");
            CreateIndex("dbo.MedicJournal", "JournalType_ID");
            AddForeignKey("dbo.MedicJournal", "JournalType_ID", "dbo.JournalTypes", "ID");
            AddForeignKey("dbo.MedicJournal", "PublisherProfile_ID", "dbo.PublisherProfiles", "ID");
        }
    }
}
