namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeRetypePassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "ConfirmPassword", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "ConfirmPassword");
        }
    }
}
