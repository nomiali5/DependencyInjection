namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FrontImageAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicJournal", "FrontImage", c => c.String());
            AddColumn("dbo.JournalTypes", "FrontImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JournalTypes", "FrontImage");
            DropColumn("dbo.MedicJournal", "FrontImage");
        }
    }
}
