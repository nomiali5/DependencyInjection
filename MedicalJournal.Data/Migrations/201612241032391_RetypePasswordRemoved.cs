namespace MedicalJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetypePasswordRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Publishers", "ReTypePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publishers", "ReTypePassword", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
