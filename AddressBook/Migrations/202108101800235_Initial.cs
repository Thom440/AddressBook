namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressBooks",
                c => new
                    {
                        AddressBookID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AddressBookID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.PersonAddressBooks",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        AddressBook_AddressBookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.AddressBook_AddressBookID })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.AddressBooks", t => t.AddressBook_AddressBookID, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.AddressBook_AddressBookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonAddressBooks", "AddressBook_AddressBookID", "dbo.AddressBooks");
            DropForeignKey("dbo.PersonAddressBooks", "Person_PersonID", "dbo.People");
            DropIndex("dbo.PersonAddressBooks", new[] { "AddressBook_AddressBookID" });
            DropIndex("dbo.PersonAddressBooks", new[] { "Person_PersonID" });
            DropTable("dbo.PersonAddressBooks");
            DropTable("dbo.People");
            DropTable("dbo.AddressBooks");
        }
    }
}
