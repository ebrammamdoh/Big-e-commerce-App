namespace AngularApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Security.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "Security.UserClaim",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(nullable: false),
                        ClaimValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClaimId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Code = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quentity = c.Int(),
                        Rate = c.Decimal(precision: 18, scale: 2),
                        ImgUrl = c.String(),
                        category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .Index(t => t.category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "category_CategoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("Security.UserClaim");
            DropTable("Security.User");
        }
    }
}
