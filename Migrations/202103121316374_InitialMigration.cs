﻿namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItem", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateOflaunch = c.DateTime(nullable: false),
                        FreeDelivery = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "MenuItemId", "dbo.MenuItem");
            DropForeignKey("dbo.MenuItem", "CategoryId", "dbo.Category");
            DropIndex("dbo.MenuItem", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "MenuItemId" });
            DropTable("dbo.Category");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Cart");
        }
    }
}
