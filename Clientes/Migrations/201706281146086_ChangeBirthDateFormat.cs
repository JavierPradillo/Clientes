namespace Clientes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBirthDateFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Identification", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "Surname", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "Phone", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "Country", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "BirthDate", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Country", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Phone", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Surname", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Name", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Identification", c => c.String(maxLength: 4000));
        }
    }
}
