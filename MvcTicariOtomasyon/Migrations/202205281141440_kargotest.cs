namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayİd = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 100, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Personel = c.String(maxLength: 20, unicode: false),
                        Alici = c.String(maxLength: 20, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayİd);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargoTakipİd = c.Int(nullable: false, identity: true),
                        Aciklama = c.String(maxLength: 300, unicode: false),
                        TakipKodu = c.String(maxLength: 10, unicode: false),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoTakipİd);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
