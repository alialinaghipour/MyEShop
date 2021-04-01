using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202104011146)]
    public class _202104011146_CreatedTableProductTag : Migration
    {

        public override void Up()
        {
            Create.Table("ProductTags")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductTags_Products", "Products", "Id")
                        .OnDelete(System.Data.Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("ProductTags");
        }
    }
}
