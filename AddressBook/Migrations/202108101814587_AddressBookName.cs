namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressBookName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddressBooks", "AddressBookName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddressBooks", "AddressBookName");
        }
    }
}
