namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriberadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalSubsubscribers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Email = c.String(maxLength: 200),
                        MedicJournalID = c.Long(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MedicJournal", "JournalSubscriber_ID", c => c.Long());
            CreateIndex("dbo.MedicJournal", "JournalSubscriber_ID");
            AddForeignKey("dbo.MedicJournal", "JournalSubscriber_ID", "dbo.JournalSubsubscribers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicJournal", "JournalSubscriber_ID", "dbo.JournalSubsubscribers");
            DropIndex("dbo.MedicJournal", new[] { "JournalSubscriber_ID" });
            DropColumn("dbo.MedicJournal", "JournalSubscriber_ID");
            DropTable("dbo.JournalSubsubscribers");
        }
    }
}
