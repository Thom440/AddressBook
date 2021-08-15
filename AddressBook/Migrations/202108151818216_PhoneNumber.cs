namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "PhoneNumber");
        }
    }
}
