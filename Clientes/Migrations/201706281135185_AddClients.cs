namespace Clientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Identification = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        Surname = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Phone = c.String(maxLength: 4000),
                        Country = c.String(maxLength: 4000),
                        BirthDate = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
