namespace _2.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.String(nullable: false, maxLength: 250, unicode: false),
                    Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    DisplayName = c.String(maxLength: 250),
                    IsActive = c.Boolean(nullable: false),
                    IsStaff = c.Boolean(nullable: false),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Log",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Method = c.String(),
                    Stacktrace = c.String(),
                    Description = c.String(),
                    IpAddress = c.String(),
                    UserName = c.String(),
                    ReferrerUrl = c.String(),
                    ApiRequest = c.String(),
                    ApiResponse = c.String(),
                    LogLevel = c.Int(nullable: false),
                    LogType = c.Int(nullable: false),
                    Xid = c.String(),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 250),
                    ProductCategoryId = c.Int(nullable: false),
                    SortDescription = c.String(maxLength: 250),
                    Description = c.String(maxLength: 4000),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ImageUrl = c.String(),
                    Stock = c.Int(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId);

            CreateTable(
                "dbo.ProductCategory",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 250),
                    ImageUrl = c.String(),
                    ShowOnMenu = c.Boolean(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Order",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    FullName = c.String(nullable: false, maxLength: 250),
                    Address = c.String(nullable: false, maxLength: 4000),
                    Email = c.String(maxLength: 8000, unicode: false),
                    Phone = c.String(nullable: false, maxLength: 32),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    IsActive = c.Boolean(nullable: false),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.OrderDetail",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Amount = c.Int(nullable: false),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreatedDateOnUtc = c.DateTime(nullable: false),
                    UpdatedDateOnUtc = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Log");
            DropTable("dbo.User");
        }
    }
}