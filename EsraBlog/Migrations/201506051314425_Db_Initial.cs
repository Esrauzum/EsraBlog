namespace EsraBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Db_Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.uyes", "Sifre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.uyes", "Sifre");
        }
    }
}
