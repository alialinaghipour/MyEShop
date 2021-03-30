using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.Migrations.Migrations
{
    [Migration(202103301145)]
    public class _202103301145_CreatedTableProdcutSelectedGroup : Migration
    {

        public override void Up()
        {
            Create.Table("ProductSelectedGroups")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductSelectedGroups_Products", "Products", "Id")
                        .OnDelete(System.Data.Rule.None)
                .WithColumn("ProductGroupId").AsInt32().NotNullable()
                    .ForeignKey("FK_ProductSelectedGroups_ProductGroups", "ProductGroups", "Id");
        }
        public override void Down()
        {
            Delete.Table("ProductSelectedGroups");
        }
    }
}
