namespace EsraBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etikets",
                c => new
                    {
                        EtiketId = c.Int(nullable: false, identity: true),
                        Icerik = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EtiketId);
            
            CreateTable(
                "dbo.Makales",
                c => new
                    {
                        MakaleId = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 50),
                        Icerik = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Uye_UyeId = c.Int(),
                    })
                .PrimaryKey(t => t.MakaleId)
                .ForeignKey("dbo.uyes", t => t.Uye_UyeId)
                .Index(t => t.Uye_UyeId);
            
            CreateTable(
                "dbo.uyes",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        EPosta = c.String(nullable: false),
                        WebSite = c.String(),
                        ResimYol = c.String(),
                        UyeOlmaTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumId = c.Int(nullable: false, identity: true),
                        Icerik = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Makale_MakaleId = c.Int(),
                        Uye_UyeId = c.Int(),
                    })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.Makales", t => t.Makale_MakaleId)
                .ForeignKey("dbo.uyes", t => t.Uye_UyeId)
                .Index(t => t.Makale_MakaleId)
                .Index(t => t.Uye_UyeId);
            
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Makale_MakaleId = c.Int(nullable: false),
                        Etiket_EtiketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Makale_MakaleId, t.Etiket_EtiketId })
                .ForeignKey("dbo.Makales", t => t.Makale_MakaleId, cascadeDelete: true)
                .ForeignKey("dbo.Etikets", t => t.Etiket_EtiketId, cascadeDelete: true)
                .Index(t => t.Makale_MakaleId)
                .Index(t => t.Etiket_EtiketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "Uye_UyeId", "dbo.uyes");
            DropForeignKey("dbo.Yorums", "Makale_MakaleId", "dbo.Makales");
            DropForeignKey("dbo.Makales", "Uye_UyeId", "dbo.uyes");
            DropForeignKey("dbo.MakaleEtikets", "Etiket_EtiketId", "dbo.Etikets");
            DropForeignKey("dbo.MakaleEtikets", "Makale_MakaleId", "dbo.Makales");
            DropIndex("dbo.MakaleEtikets", new[] { "Etiket_EtiketId" });
            DropIndex("dbo.MakaleEtikets", new[] { "Makale_MakaleId" });
            DropIndex("dbo.Yorums", new[] { "Uye_UyeId" });
            DropIndex("dbo.Yorums", new[] { "Makale_MakaleId" });
            DropIndex("dbo.Makales", new[] { "Uye_UyeId" });
            DropTable("dbo.MakaleEtikets");
            DropTable("dbo.Yorums");
            DropTable("dbo.uyes");
            DropTable("dbo.Makales");
            DropTable("dbo.Etikets");
        }
    }
}
