namespace AddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonAddressBooks", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.PersonAddressBooks", "AddressBook_AddressBookID", "dbo.AddressBooks");
            DropIndex("dbo.PersonAddressBooks", new[] { "Person_PersonID" });
            DropIndex("dbo.PersonAddressBooks", new[] { "AddressBook_AddressBookID" });
            AddColumn("dbo.People", "AddressBook_AddressBookID", c => c.Int());
            CreateIndex("dbo.People", "AddressBook_AddressBookID");
            AddForeignKey("dbo.People", "AddressBook_AddressBookID", "dbo.AddressBooks", "AddressBookID");
            DropTable("dbo.PersonAddressBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonAddressBooks",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        AddressBook_AddressBookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.AddressBook_AddressBookID });
            
            DropForeignKey("dbo.People", "AddressBook_AddressBookID", "dbo.AddressBooks");
            DropIndex("dbo.People", new[] { "AddressBook_AddressBookID" });
            DropColumn("dbo.People", "AddressBook_AddressBookID");
            CreateIndex("dbo.PersonAddressBooks", "AddressBook_AddressBookID");
            CreateIndex("dbo.PersonAddressBooks", "Person_PersonID");
            AddForeignKey("dbo.PersonAddressBooks", "AddressBook_AddressBookID", "dbo.AddressBooks", "AddressBookID", cascadeDelete: true);
            AddForeignKey("dbo.PersonAddressBooks", "Person_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
    }
}
