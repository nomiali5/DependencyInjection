namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class journaltype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 200),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MedicJournal", "JournalType_ID", c => c.Long());
            CreateIndex("dbo.MedicJournal", "JournalType_ID");
            AddForeignKey("dbo.MedicJournal", "JournalType_ID", "dbo.JournalTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicJournal", "JournalType_ID", "dbo.JournalTypes");
            DropIndex("dbo.MedicJournal", new[] { "JournalType_ID" });
            DropColumn("dbo.MedicJournal", "JournalType_ID");
            DropTable("dbo.JournalTypes");
        }
    }
}
