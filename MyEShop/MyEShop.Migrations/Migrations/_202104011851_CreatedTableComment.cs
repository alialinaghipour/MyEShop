using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202104011851)]
    public class _202104011851_CreatedTableComment : Migration
    {

        public override void Up()
        {
            Create.Table("ProductComments")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Email").AsString(250).NotNullable()
                .WithColumn("Comment").AsString(800).NotNullable()
                .WithColumn("CreateDate").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
                .WithColumn("ParentId").AsInt32().Nullable()
                    .ForeignKey("FK_ProductComments_ProductComments", "ProductComments", "Id")
                        .OnDelete(System.Data.Rule.None)
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductComments_Products", "Products", "Id")
                        .OnDelete(System.Data.Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("ProductComments");
        }
    }
}
