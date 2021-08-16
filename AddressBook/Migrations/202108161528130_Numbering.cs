namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Numbering : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Number");
        }
    }
}
