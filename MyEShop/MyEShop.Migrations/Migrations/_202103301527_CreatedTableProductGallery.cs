using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202103301527)]
    public class _202103301527_CreatedTableProductGallery : Migration
    {
        public override void Up()
        {
            Create.Table("ProductGalleries")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ImageName").AsString().NotNullable()
                .WithColumn("Title").AsString(100).NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductGalleries_Products", "Products", "Id")
                        .OnDelete(System.Data.Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("ProductGalleries");
        }

    }
}
